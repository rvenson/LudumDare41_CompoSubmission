using System.Collections;
using System.Collections.Generic;

public class CarPart {

    int performance;
    int status;

    public CarPart(){
        performance = 1;
        status = 100;
    }

    public void ApplyWear(int wear){
        status -= wear;

        if(status <= 0){
            //part is broken!
        }
    }

    

}
