window.onload = function () {
    var user = localStorage.getItem("user")
    var user = JSON.parse(user);
    var app = new Vue({
        el: '#app',
        data: {
            jokeItems: [],
            searchFilter: {
                jokesQuestion: "",
                jokesPosted: null
            },
            isNotEdit:true,
            users: {},
            jokeUpdated: false,
            jokeCreated: false,
            jokeDeleted: false,
            IsReadOnly: true,
            startDate: '',
            buttonEdit: "Edit",
            jokeItem: {
                jokesQuestion: "",
                createdAt: null,
                jokesAnswer: "",
                jokesID: null,
            },
        },
        methods: {
            fetchall: function () {
                api.getList("/seachfilter", this.searchFilter).then(data => {
                    app.jokeItems = data
                }).catch(error => console.error('Unable to edit .', error))
            },
            editLogin: async function (id) {
                this.isNotEdit = false
                await this.editasync(id);
                document.getElementById("jokesAnswer" + id).removeAttribute('readonly')
            },
            editasync: function (id) {
                if (this.buttonEdit === "Edit") {
                    document.getElementById("jokesQuestion" + id).removeAttribute('readonly')
                    document.getElementById("buttonEdit" + id).style.display = "none";
                    document.getElementById("buttonSave" + id).removeAttribute('hidden')
                }
            },
            saveLogin: function (id) {
                this.jokeItem.jokesQuestion = this.jokeItems[id].jokesQuestion
                this.jokeItem.jokesAnswer = this.jokeItems[id].jokesAnswer
                this.jokeItem.jokesID = this.jokeItems[id].jokesID
                if (this.jokeItem.createdAt === null) {
                    this.jokeItem.createdAt = this.jokeItems[id].createdAt
                }

                if (this.jokeItem.jokesID === "") {
                    api.postList("jokecreate", this.jokeItem).then(data => {
                        if (data === 1) {
                            this.jokeCreated = true
                            $("#NotificationModal").modal('show');
                            setTimeout(function () {
                                $("#NotificationModal").modal('hide');
                            }, 500);
                            setTimeout(function () {
                                location.reload();
                            }, 550);
                        }
                        
                    }).catch(error => console.error('Unable to edit .', error))
                }
                else {
                    api.postList("jokeupdate", this.jokeItem).then(data => {
                        if (data == 1) {
                            this.jokeUpdated = true
                            $("#NotificationModal").modal('show');
                            setTimeout(function () {
                                $("#NotificationModal").modal('hide');
                            }, 500);
                            setTimeout(function () {
                                location.reload();
                            }, 550);
                            
                        }
                        
                    }).catch(error => console.error('Unable to edit .', error))
                    
                }

            },
            createLogin: function () {
                newData = { jokesID: "", jokesQuestion: "", createdAt: "", jokesAnswer: "" };
                this.jokeItems.push(newData)
            },
            signOut: function (id) {
                this.jokeItem.jokesID = id
                api.postList("/signout", this.jokeItem).then(data => {
                    location.href = "/"
                }).catch(error => console.error('Unable to sighnout.', error))
            },
            deleteLogin: function (id) {
                this.jokeItem.jokesID = id
                api.postList("/jokedelete", this.jokeItem).then(data => {
                    if (data === 1) {
                        this.jokeDeleted = true
                        $("#NotificationModal").modal('show');
                        setTimeout(function () {
                            $("#NotificationModal").modal('hide');
                        }, 2000);
                        setTimeout(function () {
                            location.reload();
                        }, 2050);
                    }
                    location.reload();
                }).catch(error => console.error('Unable to delete items.', error))

            },
            openJokesModal: function (id) {
                api.getById("/lookup", id).then(data => {
                    this.jokeItem = data
                    $("#JokesModal").modal('show');

                }).catch(error => console.error('Unable to sighnout.', error))
            }

        },
        created: function () {
            this.debouncedGetAll = _.debounce(this.fetchall, 1000)
        },
        watch: {
            'searchFilter.jokesQuestion': function () {
                this.debouncedGetAll()
            },
            'searchFilter.jokesPosted': function () {
                this.fetchall()
            },
           
        },
        mounted() {
            api.getList("/jokeslist", "").then(data => {
                app.jokeItems = data
            }).catch(error => console.error('Unable to edit .', error))

            //$('#jokeDateFrom').datepicker()
            //    .on("change", function (e) {
            //        app.searchFilter.jokesDateFrom = $(this).val()
            //    });

            //$('#jokeDateTo').datepicker()
            //    .on("change", function (e) {
            //        app.searchFilter.jokesDateTo = $(this).val()
            //    });
          
            this.users = user;
        }
         
    })

}
