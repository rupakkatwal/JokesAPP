window.onload = function () {
    var app = new Vue({
        el: '#app',
        data: {
            loginCred: {
                emai: "",
                password: "",
            },
            invalidPasswordMatch: false,
            newUser: {
                Email: "",
                Password: ""
            },
            confirmPassword: "",
            isInvalid: false,
            isAuthenticated: true,
            loginItems: {}
        },
        methods: {
            submitLogin: function () {
                api.getList("/login", this.loginCred).then(data => {
                    if (data.userID === 0) {
                        app.isAuthenticated = false;
                        return;
                    }
                    localStorage.setItem('user', JSON.stringify(data));
                    location.href = "/Jokes"
                }).catch(error => console.error('Unable to get items.', error)
                )
            },
            createNewUser: function () {
                location.href = "/new"
            }

        },
        watch: {
            'logincred.UserName': function () {
                this.isAuthenticated = true;
            },
            'logincred.Password': function () {
                this.isAuthenticated = true;
            },
        }

        

    })
}