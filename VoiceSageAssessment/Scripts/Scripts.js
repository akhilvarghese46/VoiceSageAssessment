function submitGroupForm(form) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {

        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (response) {
                if (response.success) {
                    $("#viewAll").html(response.html);
                    $("#addNew").removeClass("active in");
                    $("#li_addNew").removeClass("active");
                    $("#viewAll").addClass("active in");
                    $("#li_viewall").addClass("active");
                }
                else {
                    console.log("error");

                }
            }
        });

    }
    else {
        console.log("error");
    }
    return false;
}


function editGroupDetails(url) {
        $.ajax({
            type: 'GET',
            url: url,
            success: function (response) {
                $("#addNew").html(response);      
                $("#addNew").addClass("active in");
                $("#li_addNew").addClass("active");   
                $("#viewAll").removeClass("active in");   
                $("#li_viewall").removeClass("active");  
                $("#li_addNew a").text("Edit Group"); 
            }
        });
}

function deleteGroupDetails(url) {
    if (confirm("Do you want to delete this record?") == true) {
        $.ajax({
            type: 'POST',
            url: url,
            success: function (response) {
                $("#viewAll").html(response.html);
                $("#addNew").removeClass("active in");
                $("#li_addNew").removeClass("active");
                $("#viewAll").addClass("active in");
                $("#li_viewall").addClass("active");
            }
        });
    }
}

//Contact details
function submitContactForm(form) {
    
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {

        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (response) {
                if (response.success) {
                    $("#viewAll").html(response.html);
                    $("#addNew").removeClass("active in");
                    $("#li_addNew").removeClass("active");
                    $("#viewAll").addClass("active in");
                    $("#li_viewall").addClass("active");
                }
                else {
                    console.log("error");

                }
            }
        });

    }
    else {
        console.log("error");
    }
    return false;
}

function editContactDetails(url) {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (response) {
            $("#addNew").html(response);
            $("#addNew").addClass("active in");
            $("#li_addNew").addClass("active");
            $("#viewAll").removeClass("active in");
            $("#li_viewall").removeClass("active");
            $("#li_addNew a").text("Edit Group");
        }
    });
}


function deleteContactDetails(url) {
    if (confirm("Do you want to delete this record?") == true) {
        $.ajax({
            type: 'POST',
            url: url,
            success: function (response) {
                $("#viewAll").html(response.html);
                $("#addNew").removeClass("active in");
                $("#li_addNew").removeClass("active");
                $("#viewAll").addClass("active in");
                $("#li_viewall").addClass("active");
            }
        });
    }
}