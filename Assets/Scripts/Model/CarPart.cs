using System.Collections;
using System.Collections.Generic;

public class CarPart {

    float performance;
    float status;

    public CarPart(){
        performance = 1;
        status = 100;
    }

    public void ApplyWear(float wear){
        status -= wear;

        if(status <= 0){
            //part is broken!
        }
    }

    public float GetPerformance(){
        return performance;
    }

    public float GetStatus(){
        return status;
    }
    

}
