#include <unity.h>
#include <iostream>
#include "../lib/RingBuffer/RingBuffer.h"


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

void Consume_WhenCap4AndProd4_4(){
    RingBuffer rBuffer(4) ;
    rBuffer.Produce(50);
    rBuffer.Produce(51);
    rBuffer.Produce(52);
    rBuffer.Produce(53);
    

    for(int i=0; i<4; i++){
        char x = 0;
        rBuffer.Consume(x);

        TEST_ASSERT_TRUE(x == (50+i));
    }
}

void Consume_WhenCap4AndProd5_firstConsumedEqualLastProduced(){
    RingBuffer rBuffer(4) ;
    rBuffer.Produce(50);
    rBuffer.Produce(51);
    rBuffer.Produce(52);
    rBuffer.Produce(53);
    rBuffer.Produce(54);
    
    char x = 0;
    TEST_ASSERT_TRUE(rBuffer.Consume(x));

    TEST_ASSERT_TRUE(x == 54);
}

void Consume_WhenCap4AndProd5AndCons1after2Prod_ConsumingBlocked(){
    RingBuffer rBuffer(4) ;
    char x = 0;

    rBuffer.Produce(50); // first production
    rBuffer.Produce(51); // second production
    rBuffer.Consume(x);  // first consume => 50
    rBuffer.Produce(52);
    rBuffer.Produce(53);
    rBuffer.Produce(54);
    
    x=0;
    TEST_ASSERT_FALSE(rBuffer.Consume(x));  
    
}

void Consume_WhenCap4AndProd5AndCons3after4Prod_Cons2Last(){
    RingBuffer rBuffer(4) ;
    char x = 0;

    rBuffer.Produce(50); // first production
    rBuffer.Produce(51); // second production
    rBuffer.Produce(52); // third production
    rBuffer.Produce(53); // fourth production
    rBuffer.Consume(x);  // first consume => 50
    rBuffer.Consume(x);  // second consume => 51
    rBuffer.Consume(x);  // third consume => 52
    rBuffer.Produce(54); // fifth production
    
    x=0;
    TEST_ASSERT_TRUE(rBuffer.Consume(x)); // fourth consumption 53 
    TEST_ASSERT_TRUE(x == 53);
    x=0;
    TEST_ASSERT_TRUE(rBuffer.Consume(x)); // fifth consumption 54 
    TEST_ASSERT_TRUE(x == 54);
}


void Consume_OneProductionTwoConsumption_LastConsumptionReturnFalse(){
    RingBuffer rBuffer(4) ;
    char x = 0;

    rBuffer.Produce(50); // first production
    x=0;
    TEST_ASSERT_TRUE(rBuffer.Consume(x)); // first consumption
    x=0;
    TEST_ASSERT_FALSE(rBuffer.Consume(x)); // second consumption
}

int main( int argc, char **argv) {
    UNITY_BEGIN();
    RUN_TEST(GetBufferSize_Capacity1024_1024);
    RUN_TEST(Consume_ProduceOneByte50_50);
    RUN_TEST(Consume_Produce10Bytes_10Bytes);
    RUN_TEST(Consume_WhenCap4AndProd4_4);
    RUN_TEST(Consume_WhenCap4AndProd5_firstConsumedEqualLastProduced);
    RUN_TEST(Consume_WhenCap4AndProd5AndCons1after2Prod_ConsumingBlocked) ;
    RUN_TEST(Consume_WhenCap4AndProd5AndCons3after4Prod_Cons2Last);
    RUN_TEST(Consume_OneProductionTwoConsumption_LastConsumptionReturnFalse);
    UNITY_END();
}