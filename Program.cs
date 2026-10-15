using CommandPattern.Classes;
using CommandPattern.Classes.Commands;
using CommandPattern.Interfaces;

namespace CommandPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RemoteControl remoteControl = new RemoteControl();

            /* Define and instantiate the following Vendor classes
             * Kitchen Light : Light
             * Livingroom Light : Light
             * Livingroom ceiling fan : CeilingFan
             * Garage door: Garagedoor
             * Stereo : Stereo
             */
            Light kitchenLight = new Light("Kitchen");
            Light livingRoomLight = new Light("Living Room");
            Light garageLight = new Light("Garage");
            CeilingFan livingRoomCeilingFan = new CeilingFan("Living Room");
            GarageDoor garageDoor = new GarageDoor(garageLight);
            Stereo stereo = new Stereo();
            
            LightOnCommand livingRoomLightOn = new LightOnCommand(livingRoomLight);
            LightOffCommand livingRoomLightOff = new LightOffCommand(livingRoomLight);

            LightOnCommand kitchenLightOn = new LightOnCommand(kitchenLight);
            LightOffCommand kitchenLightOff = new LightOffCommand(kitchenLight);

            
            CeilingFanHighCommand ceilingFanHigh = new CeilingFanHighCommand(livingRoomCeilingFan);
            CeilingFanOffCommand ceilingFanOff = new CeilingFanOffCommand(livingRoomCeilingFan);

            GarageDoorUpCommand garageDoorUp = new GarageDoorUpCommand(garageDoor);
            GarageDoorDownCommand garageDoorDown = new GarageDoorDownCommand(garageDoor);

            StereoOnWithCdCommand stereoOnWithCD = new StereoOnWithCdCommand(stereo);
            StereoOffCommand stereoOff = new StereoOffCommand(stereo);
            /* Set the On and Off commands to the appropriate slot:
             * 
             * 1: Living Room light
             * 2: Kitchen light
             * 3: Livingroom ceiling fan
             * 4: Garage door
             * 5: Stereo
             */
            remoteControl.SetCommand(1, livingRoomLightOn, livingRoomLightOff);
            remoteControl.SetCommand(2, kitchenLightOn, kitchenLightOff);
            remoteControl.SetCommand(3, ceilingFanHigh, ceilingFanOff);
            remoteControl.SetCommand(4, garageDoorUp, garageDoorDown);
            remoteControl.SetCommand(5, stereoOnWithCD, stereoOff);

            Console.WriteLine(remoteControl);

            Console.WriteLine("--- Testing Remote Buttons ---");

            remoteControl.OnButtonWasPushed(1);
            remoteControl.OffButtonWasPushed(1);

            remoteControl.OnButtonWasPushed(2);
            remoteControl.OffButtonWasPushed(2);

            remoteControl.OnButtonWasPushed(5);
            remoteControl.OffButtonWasPushed(5);

            Console.WriteLine("\n--- Testing Undo Functionality ---");

            Console.WriteLine("1. Turning Living Room Light ON:");
            remoteControl.OnButtonWasPushed(1);

            Console.WriteLine("2. Undoing last action (should turn Living Room Light OFF):");
            remoteControl.UndoButtonWasPushed();
            
            Console.WriteLine("\n3. Setting Ceiling Fan to HIGH:");
            remoteControl.OnButtonWasPushed(3); 

            Console.WriteLine("4. Turning Ceiling Fan OFF:");
            remoteControl.OffButtonWasPushed(3); 

            Console.WriteLine("5. Undoing last action (should restore Ceiling Fan to HIGH):");
            remoteControl.UndoButtonWasPushed();

            Console.WriteLine("\n--- Testing Undo History (Opdracht 3) ---");

            remoteControl.OnButtonWasPushed(1);
            remoteControl.OnButtonWasPushed(2);
            remoteControl.OnButtonWasPushed(3);

            Console.WriteLine("\n[undo 3 keer]");
            remoteControl.UndoButtonWasPushed();
            remoteControl.UndoButtonWasPushed();
            remoteControl.UndoButtonWasPushed();

            Console.ReadKey();

            // Test the pressing of Buttons here. Don't forget to test the Undo button


        }
    }
}