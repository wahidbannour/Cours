#include "RingBuffer.h"
#include <string.h>

RingBuffer::RingBuffer(int capacity){
    this->capacity = capacity;
    buffer = std::vector<char>(capacity);
}

RingBuffer::~RingBuffer(){
    
}

inline int RingBuffer::GetCurrentPosition(){
    int currentProducingIndex;
    while(true){
        if(writeMutex.try_lock()){
            //think to disable interrupt
            currentProducingIndex = producingIndex;
            writeMutex.unlock();
            //and enable interrupt after
            return currentProducingIndex;
        }
    }
}

int RingBuffer::GetBufferSize(){
    return capacity;
}

int  RingBuffer::GetInBufferCount(){
    auto currentProducingIndex = GetCurrentPosition();
    if((currentProducingIndex == consumingIndex) && !ProducerDepassCapacity ) 
        return 0;
    if(currentProducingIndex > consumingIndex)
        return currentProducingIndex-consumingIndex;
    else 
       // if(ProducerDepassCapacity)
       //     return (capacity - consumingIndex) + currentProducingIndex;
       // else
            return (capacity - consumingIndex) + currentProducingIndex;
}

void RingBuffer::Produce(char byte){
    if(producingIndex < capacity)
    {
        writeMutex.lock();
        buffer[producingIndex++] = byte;
        if(producingIndex >= capacity){
           
            ProducerDepassCapacity= true;
        }
        writeMutex.unlock();
    }
    else{
        writeMutex.lock();
        
        ProducerDepassCapacity= true;
        buffer[producingIndex++] = byte;
        writeMutex.unlock();
    }
}

bool RingBuffer::Consume(char& byte){
    int currentProducingIndex;
    
    currentProducingIndex = GetCurrentPosition();
    if(consumingIndex < currentProducingIndex){
        byte= buffer[consumingIndex++];
        if(consumingIndex> capacity){
            consumingIndex =0;
             while(true){
                if(writeMutex.try_lock()){
                    ProducerDepassCapacity =false;
                    writeMutex.unlock(); 
                    break;   
                }
            }
        }
        return true;
    }
    else{
        if((consumingIndex == currentProducingIndex) && !ProducerDepassCapacity)
            return false;
        byte= buffer[consumingIndex++];    
        if (consumingIndex > capacity){
            
             while(true){
                if(writeMutex.try_lock()){
                    ProducerDepassCapacity =false;
                    writeMutex.unlock(); 
                    break;   
                }
            }
        }
            
        
        return true;
    }
    return false;   
}

bool RingBuffer::BulkConsume(char& destination, int size){
    int currentProducingIndex;
    int difference;
    currentProducingIndex = GetCurrentPosition();
    if(consumingIndex <= currentProducingIndex ){
        difference = currentProducingIndex - consumingIndex ;
        if(difference >= size){
            memcpy(&destination, &buffer[consumingIndex], size);
            consumingIndex = currentProducingIndex;
            return true;
        }
    }
    else{
      difference = (capacity - consumingIndex) + currentProducingIndex;
      if(difference >= size)
      {
        memcpy(&destination, &buffer[consumingIndex+1], (capacity - consumingIndex));
        memcpy(&destination + capacity - consumingIndex + 1, &buffer, currentProducingIndex);
        consumingIndex = currentProducingIndex;
        return true;
      }
    }
    return false;  
}