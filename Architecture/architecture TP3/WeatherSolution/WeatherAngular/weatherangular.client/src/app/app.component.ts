import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { WeatherInfo } from './valueObjects/weatherInfo'
import { WeatherConfig } from './valueObjects/weatherConfig'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent implements OnInit {
  weathers: WeatherInfo[] = [];
  config: WeatherConfig = {
    hasPrecipitation: true,
    hasPression: true,
    hasTemperature: true,
    hasWind: true,
  };
  
  subscription: any;
  isStarted: boolean = false;
  isInitialized = false;
  timeLookup: number = 15000;

  constructor(private http: HttpClient) {}
  
  startTimer() {
    setInterval(() => {
      if (this.isStarted) {
        this.getWeatherInfo();
      }
    }, this.timeLookup)
  }

  ngOnInit() {
    this.getConfig();
    this.startTimer(); 
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
  
  getWeatherInfo() {
    this.http.get<WeatherInfo[]>('/api/weather/GetInfo').subscribe(
      (result) => {
        this.weathers = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }
  getConfig() {
    this.http.get<WeatherConfig>('/api/weather/GetConfig').subscribe(
      (result) => {
        if (result == null)
          this.isInitialized = false;
        else {
          this.config = result;
          this.isInitialized = true;
        }
      },
      (error) => {
        console.error(error);
      }
    );
  }
  onConfiguration(){
    this.http.post<WeatherConfig>('/api/weather/SetConfig',this.config).subscribe(
      
      (error) => {
        console.error(error);
      }
    );
    this.isInitialized = true;
  }

  onStart() {
    this.weathers = [];
    this.http.get('/api/weather/Start').subscribe(
      (error) => {
        console.error(error);
      }
    );
    this.isStarted = true;
  }

  onStop(){
    this.http.get('/api/weather/Stop').subscribe(
      (error) => {
        console.error(error);
      }
    );
    this.isStarted = false;
  }
  onConfigChanged() {
    this.isInitialized = false;
    this.weathers = [];
  }
  title = 'weatherangular.client';
}
