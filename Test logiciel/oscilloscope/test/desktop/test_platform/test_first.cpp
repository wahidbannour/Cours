#include <unity.h>


void setUp(void) {
    // set stuff up here
}

void tearDown(void) {
    // clean stuff up here
}


void first_test() {
    TEST_ASSERT_TRUE(1==1);
}

void second_test() {
    TEST_ASSERT_FALSE(1==0);
}



int main( int argc, char **argv) {
    UNITY_BEGIN();

    RUN_TEST(first_test);
    RUN_TEST(second_test);
    
    UNITY_END();
}