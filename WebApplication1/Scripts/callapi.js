$.ajax({
    url: 'http://localhost:52520/api/User',
    method: 'POST',
    dataType: 'json',
    contentType: 'application/json; charset=utf-8',
    data: User,
    success: function (data) {
        alert("Saved successfully");
    },
    fail : function( jqXHR, textStatus ) {
    alert("Request failed: " + textStatus);
    }
})
