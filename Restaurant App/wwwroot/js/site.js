// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:7206/api/Menu/GetMenu',
        type: 'GET',
        success: function (data1) {
            var html = '';
            for (var index = 0; index < data1.length; index++) {
                console.log(data1[index]);
                html += ('<option value="' + data1[index].menuID + '">' + data1[index].cusine + '</option>');
            }
            $('#menuList').append(html);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Status: " + textStatus);
            alert("Error: " + errorThrown);
        }
    });

    $('#menuList').change(function () {
        var menuselected = $('#menuList').val();
        //alert(menuselected);
        $.ajax({
            url: 'https://localhost:7206/api/Menu/GetChoice',
            type: 'GET',
            success: function (data1) {
                var html = '<option value=" ">' + "Select" + '</option>';
                for (var index = 0; index < data1.length; index++) {
                    console.log(data1[index]);
                    html += ('<option value="' + data1[index].choiceID + '">' + data1[index].category + '</option>');
                }
                $('#choiceList').html(html);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Status: " + textStatus);
                alert("Error: " + errorThrown);
            }
        });

    });
    $('#choiceList').change(function () {
        var choiceList = $('#choiceList').val();
        //alert(choiceList);
        var menuselected = $('#menuList').val();
        $.ajax({
            url: 'https://localhost:7206/api/Menu/GetMenuCard?Mid=' + menuselected + '&Cid=' + choiceList,

            type: 'GET',
            success: function (data1) {
                var html = '';
                for (var index = 0; index < data1.length; index++) {
                    console.log(data1[index]);
                    html += ('<tr>' +
                        '<td>' + data1[index].dishId + '</td>' +
                        '<td>' + data1[index].dishName + '</td>' +
                        '<td>' + data1[index].price + '</td>' +
                        '</tr>');
                }
                $('#tbody').html(html);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Status: " + textStatus);
                alert("Error: " + errorThrown);
            }
        });
    });
    $('#btnCreate').click(function () {
        var dId = $('#DishId').val();
        var dName = $('#DishName').val();
        var price = $('#Price').val();
        var mId = $('#MenuID').val();
        var cId = $('#ChoiceID').val();
        var frmdata = {
            dishId: dId,
            dishName: dName,
            price: price,
            menuID: mId,
            choiceID: cId


        };
    //    alert(dId);
    $.ajax({
        url: 'https://localhost:7206/api/Menu/AddDish',
        type: 'POST',
        data: frmdata, 
        success: function (data) {
            console.log(data);
            alert("New Student created successfully.");
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Status: " + textStatus);
            alert("Error: " + errorThrown);
        }
        });
})

            //$('#btnCreate').click(function (e) {
            //    alert(1);
            //    var formData = $('#frmCreateStudent').serialize();

            //    console.log(formData);
            //    $.ajax({
            //        url: 'https://localhost:7206/api/Menu/AddDish',
            //        type: "POST",
            //        data: formData,
            //        success: function (data, textStatus, jqXHR) {
            //            console.log(data);
            //            if (data.Success) {
            //                alert("New Student created successfully.");
            //            }
            //            else {
            //                alert("Error");
            //                alert(data.Error);
            //            }
            //        },
            //        error: function (jqXHR, textStatus, errorThrown) {
            //            alert("Status: " + textStatus);
    //                    alert("Error: " + errorThrown);
    //                }

    //    }
    //});

});


//change function 

//onchange event, include a form, radio buttons or drop down, make ajax call accordingly.


 //for hover table
    //function openplace(evt, mallName) {
    //        var i, tabcontent, tablinks;
    //tabcontent = document.getElementsByClassName("tabcontent");
    //for (i = 0; i < tabcontent.length; i++) {
    //    tabcontent[i].style.display = "none";
    //        } //hidden tab contents
    //tablinks = document.getElementsByClassName("tablinks");
    //for (i = 0; i < tablinks.length; i++) {
    //    tablinks[i].className = tablinks[i].className.replace(" active", "");
    //        }
    //document.getElementById(mallName).style.display = "block";
    //evt.currentTarget.className += " active";
    //    } //checking to see if it is matching with the button hovederd upon.

    //for slide show
    //var slideIndex = 1;
    //showSlides(slideIndex);

    //// Next/previous controls
    //function plusSlides(n) {
    //    showSlides(slideIndex += n);
    //    }

    //// Thumbnail image controls
    //function currentSlide(n) {
    //    showSlides(slideIndex = n);
    //    }

    //function showSlides(n) {
    //        var i;
    //var slides = document.getElementsByClassName("mySlides");
    //var dots = document.getElementsByClassName("dot");
    //        if (n > slides.length) {slideIndex = 1}
    //if (n < 1) {slideIndex = slides.length}
    //for (i = 0; i < slides.length; i++) {
    //    slides[i].style.display = "none";
    //        }
    //for (i = 0; i < dots.length; i++) {
    //    dots[i].className = dots[i].className.replace(" active", "");
    //        }
    //slides[slideIndex - 1].style.display = "block";
    //dots[slideIndex - 1].className += " active";
    //    }
//ajax get call the api and get the data