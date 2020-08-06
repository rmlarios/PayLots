function toastify(type, msg, title, position, showclosebutton) {
   
        //toastr.options.positionClass =position;
    
   
    toastr.options = {
       
        "debug": false,
        "positionClass": "toast-bottom-full-width",
        "closeButton": true,
        "progressBar": true,
        "preventDuplicates": false,
        "showDuration": "400",
        "hideDuration": "1000",
        "timeOut": "7000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
    toastr[type](msg, title);

}