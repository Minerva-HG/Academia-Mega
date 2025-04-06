const AuthModule = (function(){
    //simular usuario
    const userDB = {
        username:"admin",
        password:"1234"
    }

    let currentUSer = null;

    return{
        login(username, password){
            if(username === userDB.username && password === userDB.password){
               currentUSer = UserSingleton.getInstance(username); 
               console.log(`Usuario Autentificado : $(currentUser.name)`)
            
            }else{

                console.log("Credenciales incorrectas")
            }
        },

            logout(){
                if(currentUSer){
                    console.log(`Hasta Luego, $(currentUser.name)`)
                    currentUSer = null;
                    UserSingleton.clearIntance();

                }else{
                    console.log("No hay usuario auntentificado")
                }
            }

        //}
    }

})();