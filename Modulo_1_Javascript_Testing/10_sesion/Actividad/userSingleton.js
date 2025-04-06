const UserSingleton = (function(){
    let instance = null;

    function createInstance(name){
        return{
            name,
            loginTime: new Data().toLocalDataString()
        }
    }


    return{
        getInstance(name){
            if(instance){
                instance = createInstance(name)

            }
            return instance
        },
        clearIntance(){
            instance = null;
        }
    }

})();