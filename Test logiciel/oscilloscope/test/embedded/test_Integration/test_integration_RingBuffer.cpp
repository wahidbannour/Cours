#include <unity.h>
#include <arduino.h>
#include "../lib/RingBuffer/RingBuffer.h"
#include "oscilloscope.h"

hw_timer_s *sampling_timer = NULL ;
RingBuffer sharedRingBuffer(10) ;
char productionBuffer[10]= {1,2,3,4,5,6,7,8,9,10};
volatile int bufferIndex = 0 ;

void IRAM_ATTR OnOneMsTimer(){
    if(bufferIndex < 10)
        sharedRingBuffer.Produce(productionBuffer[bufferIndex++]);
}


void setUp(void) {
    // set stuff up here
}

void tearDown(void) {
    // clean stuff up here
}


void GetBufferSize_Capacity1024_1024() {
    
    RingBuffer rBuffer(1024) ;
    
    auto x = rBuffer.GetBufferSize();

    TEST_ASSERT_TRUE(x==1024);
}

void Consume_ProduceOneByte50_50(){
    RingBuffer rBuffer(100) ;
    rBuffer.Produce(50);
    char x = 0;

    rBuffer.Consume(x);

    TEST_ASSERT_TRUE(x==50);
}

void Consume_Produce10Bytes_10Bytes(){
    RingBuffer rBuffer(100) ;
    for(int i =0; i<10 ;i++)
        rBuffer.Produce(i);
    

    for(int i =0; i<10 ;i++){
        char x = 0;
        rBuffer.Consume(x);
        TEST_ASSERT_TRUE(x==i);
    }
}

void Consume_When2Thread_AndCap10AndProdEvery1ms_AndConsAfter5ms_Read5ValueInOrder(){
    
    bufferIndex = 0;
    sampling_timer = timerBegin(1, 80, true);
    timerAttachInterrupt(sampling_timer, &OnOneMsTimer, true);
    timerAlarmWrite(sampling_timer, ONE_Milli_SECOND, true);
    timerAlarmEnable(sampling_timer);
    delay(5);
    char x=0;
    TEST_ASSERT_TRUE(sharedRingBuffer.Consume(x));
    TEST_ASSERT_TRUE(x == 1);
    x=0;
    TEST_ASSERT_TRUE(sharedRingBuffer.Consume(x));
    TEST_ASSERT_TRUE(x == 2);
    x=0;
    TEST_ASSERT_TRUE(sharedRingBuffer.Consume(x));
    TEST_ASSERT_TRUE(x == 3);
    x=0;
    TEST_ASSERT_TRUE(sharedRingBuffer.Consume(x));
    TEST_ASSERT_TRUE(x == 4);
    x=0;
    TEST_ASSERT_TRUE(sharedRingBuffer.Consume(x));
    TEST_ASSERT_TRUE(x == 5);
    
    timerAlarmDisable(sampling_timer);
    
}

void Consume_When2Thread_AndCap10AndProdEvery1ms_AndConsAfter5ms_TheSixthConsIsBlocked(){
    bufferIndex = 0;
    sampling_timer = timerBegin(1, 80, true);
    timerAttachInterrupt(sampling_timer, &OnOneMsTimer, true);
    timerAlarmWrite(sampling_timer, ONE_Milli_SECOND, true);
    timerAlarmEnable(sampling_timer);
    delay(5);
    char x=0;
    TEST_ASSERT_TRUE(sharedRingBuffer.Consume(x));
    TEST_ASSERT_TRUE(x == 1);
    x=0;
    TEST_ASSERT_TRUE(sharedRingBuffer.Consume(x));
    TEST_ASSERT_TRUE(x == 2);
    x=0;
    TEST_ASSERT_TRUE(sharedRingBuffer.Consume(x));
    TEST_ASSERT_TRUE(x == 3);
    x=0;
    TEST_ASSERT_TRUE(sharedRingBuffer.Consume(x));
    TEST_ASSERT_TRUE(x == 4);
    x=0;
    TEST_ASSERT_TRUE(sharedRingBuffer.Consume(x));
    TEST_ASSERT_TRUE(x == 5);
    x=0;
    TEST_ASSERT_FALSE(sharedRingBuffer.Consume(x));
    
    timerAlarmDisable(sampling_timer);
}

void Consume_When2Thread_AndCap10AndProdEvery1ms_AndConsAfterEvery5ms_Read10ValueInOrder(){
    bufferIndex = 0;
    sampling_timer = timerBegin(1, 80, true);
    timerAttachInterrupt(sampling_timer, &OnOneMsTimer, true);
    timerAlarmWrite(sampling_timer, ONE_Milli_SECOND, true);
    timerAlarmEnable(sampling_timer);
    delay(5);
    char x=0;
    sharedRingBuffer.Consume(x);
    sharedRingBuffer.Consume(x);
    sharedRingBuffer.Consume(x);
    sharedRingBuffer.Consume(x);
    sharedRingBuffer.Consume(x);
    delay(5);
    sharedRingBuffer.Consume(x);
    sharedRingBuffer.Consume(x);
    sharedRingBuffer.Consume(x);
    sharedRingBuffer.Consume(x);
    
    x=0;
    TEST_ASSERT_TRUE(sharedRingBuffer.Consume(x));
    TEST_ASSERT_TRUE(x == 10);
    
    timerAlarmDisable(sampling_timer);
}

void setup(){

    delay(2000);    // for boot latency purpose
    Serial.begin(115200);

    UNITY_BEGIN();
    
    RUN_TEST(GetBufferSize_Capacity1024_1024);
    RUN_TEST(Consume_ProduceOneByte50_50);
    RUN_TEST(Consume_Produce10Bytes_10Bytes);
    RUN_TEST(Consume_When2Thread_AndCap10AndProdEvery1ms_AndConsAfter5ms_Read5ValueInOrder);
    RUN_TEST(Consume_When2Thread_AndCap10AndProdEvery1ms_AndConsAfter5ms_TheSixthConsIsBlocked);
    RUN_TEST(Consume_When2Thread_AndCap10AndProdEvery1ms_AndConsAfterEvery5ms_Read10ValueInOrder);


    UNITY_END();
}

void loop(){


}