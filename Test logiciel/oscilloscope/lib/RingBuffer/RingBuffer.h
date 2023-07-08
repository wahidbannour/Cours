
//#ifndef MAX_LENGTH_BUFFER
//#define MAX_LENGTH_BUFFER 100
//#endif
#include <vector>
#include <mutex>

using namespace std;


class RingBuffer{

    private :
        int capacity = 100;
        vector<char> buffer;
        mutex writeMutex;
        int consumingIndex = 0;
        int producingIndex = 0;
        inline int GetCurrentPosition();
    public:
        void Produce(char byte);
        bool Consume(char& byte);
        bool BulkConsume(char& destination, int size);
        int GetBufferSize();
        RingBuffer(int capacity);
        ~RingBuffer();
};