window.ShowToastr = (type, message) => {
    if (type == "success") {
        toastr.success(message, 'Operation successful', { timeOut: 5000 });
    }
    if (type == "error") {
        toastr.error(message, 'Operation failed', { timeOut: 5000 });
    }
}

window.ShowSweetAlert = (type, title, message) => {
    if (type == "success") {
        Swal.fire(
            title,
            message,
            'success'
        )

    }
    if (type == "error") {
        Swal.fire(
            title,
            message,
            'error'
        )
    }
}

function ShowDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('show');
}

function HideDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('hide');
}