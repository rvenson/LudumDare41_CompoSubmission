using System.Collections;
using System.Collections.Generic;

public class Driver {

    string driverName;
    int dexterity;
    int consistency;
    int overtaking;

    public Driver(){
        driverName = "TestPilot";
        dexterity = 1;
        consistency = 1;
        overtaking = 1;
    }

    public string GetDriverName(){
        return driverName;
    }

    public void SetDriverName(string name){
        driverName = name;
    }

}
