window.showModal = function (modalId) {
    console.log("showModal called with:", modalId);
    var modalEl = document.getElementById(modalId);
    if (modalEl) {
        var modal = new bootstrap.Modal(modalEl);
        modal.show();
    } else {
        console.error("Modal element not found:", modalId);
    }
};