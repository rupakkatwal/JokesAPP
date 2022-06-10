window.onload = function () {
    var app = new Vue({
        el: '#app',
        data: {
            invalidPasswordMatch: false,
            newUser: {
                Email: "",
                Password: ""
            },
            alreadyExist: false,
            checkUser: null,
            createNew: false,
            confirmPassword: "",
            isInvalid: false,
          
        },
        methods: {
            createNewUser: function () {

                if (this.newUser.Email === "" || this.newUser.Password === "" || this.confirmPassword === "") {
                    this.isInvalid = true
                    return;
                }
                if (this.newUser.Password !== this.confirmPassword) {
                    this.invalidPasswordMatch = true
                    return;
                }
                api.postList("/usercreate", this.newUser).then(data => {
                    app.checkUser = data
                    if (app.checkUser  === 0) {
                        app.alreadyExist = true;
                        $("#UserModal").modal('show');
                    }
                    else {
                        app.createNew = true;
                        $("#UserModal").modal('show');
                    }

                }).catch(error => console.error('Unable to edit .', error))
                app.alreadyExist = false;
                app.createNew = false;
            }

        }
        

    })
}