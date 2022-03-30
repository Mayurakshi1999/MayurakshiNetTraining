$(document).ready(function () {
    $.ajax({
        url: '/Student/GetAllStudentsJSON',
        type: 'GET',
        success: function (data) {
            //alert(1);
            console.log(data);
            var htmlText = '';
            for (var i = 0; i < data.length; i++) {
                var tr = '<tr><td>' + data[i].FN + '</td><td>' + data[i].LN + '</td><td>' + data[i].RollNo + '</td><td>' + data[i].Marks + '</td></tr>';
                htmlText += tr;
                //console.log(htmlText);


            }
            $('#tblData').html(htmlText);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Status: " + textStatus);
            alert("Error: " + errorThrown);
        }
    });

});