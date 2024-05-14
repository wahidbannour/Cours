
#include <ValueObject/DigitalOutputs.hpp>
#include <CommandLed.hpp>

CommandLed::CommandLed(IDigitalIo& io){
    this->io = &io;

}

void CommandLed::Configure(Outputs& out, LedLogicCommand& ledCommand){
  this->out = out;
  this->ledCommand = ledCommand;
}

void CommandLed::ActivateLight(){
  io->DigitalWrite(out.Led,ledCommand.LedOn);//LIGHT, LIGHTON
}

void CommandLed::DiactivateLight(){
  io->DigitalWrite(out.Led,ledCommand.LedOff);//LIGHT, LIGHTOFF
}

