var api = {
    getById: (url,id) =>{
        return $.getJSON(url + '/' + id)
        .catch()
    },
    getList:function(url, data){
        return $.getJSON(url, data)
    },

     postList: function (url, data) {
        return $.post(url, data)
    }

}
