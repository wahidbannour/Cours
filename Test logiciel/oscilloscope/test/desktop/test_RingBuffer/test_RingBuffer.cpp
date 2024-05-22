#include <unity.h>
#include <iostream>
#include <RingBuffer.h>

void setUp(void) {
    // set stuff up here
}

void tearDown(void) {
    // clean stuff up here
}

// nomFonction_scénario_resultat attendu

void GetBufferSize_Capacity1024_1024() {
    //Arrange
    RingBuffer rBuffer(1024) ;
    //Action
    auto x = rBuffer.GetBufferSize();
    //Assert
    TEST_ASSERT_TRUE(x==1024);
}




int main( int argc, char **argv) {
    UNITY_BEGIN();
    RUN_TEST(GetBufferSize_Capacity1024_1024);
    RUN_TEST(Consume_ProduceOneByte50_50);
    RUN_TEST(Consume_Produce10Bytes_10Bytes);
    RUN_TEST(Consume_WhenCap4AndProd4_4);
    RUN_TEST(Consume_WhenCap4AndProd5_firstConsumedEqualLastProduced);
    RUN_TEST(Consume_WhenCap4AndProd5AndCons1after2Prod_ConsumingSecondProduction) ;
    RUN_TEST(Consume_WhenCap4AndProd5AndCons3after4Prod_Cons2Last);
    RUN_TEST(Consume_OneProductionTwoConsumption_LastConsumptionReturnFalse);
    RUN_TEST(Consume_WhenProductionAndConsumeFullCapacityTwice_GetLastPeoduction);
    RUN_TEST(Consume_WhenProductionAndConsumeFullCapacityThreeTimes_GetLastPeoduction);
    RUN_TEST(GetInBufferCount_OneProdAndOneCons_Zero);
    RUN_TEST(GetInBufferCount_TwoProdAndTwoCons_Zero);
    RUN_TEST(GetInBufferCount_FourProdAndFourConsAndCapacityFour_Zero);
    RUN_TEST(GetInBufferCount_FourProdAndTwoConsAndCapacityFour_Two);
    RUN_TEST(GetInBufferCount_FourProdAndZeroConsAndCapacityFour_Four);
    RUN_TEST(GetInBufferCount_FiveProdAndOneConsAndCapacityFour_Four);
    RUN_TEST(GetInBufferCount_FiveProdAndTwoConsAndCapacityFour_Three);
    RUN_TEST(GetInBufferCount_OneCycleConsumBetweenTwoCycleProdAndCapacityFour_Four);
    
    UNITY_END();
}