#include <unity.h>
#include <arduino.h>



void first_test() {
    TEST_ASSERT_TRUE(1==1);
}

void second_test() {
    TEST_ASSERT_FALSE(1==0);
}



void setup(){

    delay(2000);    // for boot latency purpose
    Serial.begin(115200);

    UNITY_BEGIN();
    RUN_TEST(first_test);
    RUN_TEST(second_test);

    UNITY_END();
}

void loop(){

}

