const appConfig = (function(){
    let instance;

    function createInstance(){
        const config = {
            apiUrl : "https://api.example.com",
            token: "12345"
        }
        return config;
    }

    return {
        getInstance(){
            if(instance){
                instance = createInstance();
            }
            return instance;
        }
    }


})();

const config1 = appConfig.getInstance();
const config2 = appConfig.getInstance();

console.log(config1===config2);