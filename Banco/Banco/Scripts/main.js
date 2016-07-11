$('html,body').animate({
    scrollTop: $("#scrollToHere").offset().top
}, 2000);

$("#miBoton").click(function () {
    $('html,body').animate({
        scrollTop: $("#scrollToHere").offset().top
    }, 2000);
});

$('#textarea1').trigger('autoresize');

$('.dropdown-button').dropdown({
    inDuration: 300,
    outDuration: 225,
    constrain_width: false, // Does not change width of dropdown to that of the activator
    hover: true, // Activate on hover
    gutter: 0, // Spacing from edge
    belowOrigin: false, // Displays dropdown below the button
    alignment: 'left' // Displays dropdown with edge aligned to the left of button
}
  );

$('cuadrocom').addClass('display:block;');

function comentario() {
    var comment = document.getElementsByName('comment')[0].value;
    $.ajax({
        data: comment,
        url: 'ejemplo_ajax_proceso.php',
        type: 'post',
        beforeSend: function () {
            $("#resultado").html("Procesando, espere por favor...");
        },
        success: function (response) {
            $("#resultado").html(response);
        }
    });
}
