window.addEventListener("load", solve);

function solve() {
    let roomSizeInput = document.getElementById('room-size');
    let timeSlotInput = document.getElementById('time-slot');
    let fullNameInput = document.getElementById('full-name');
    let emailInput = document.getElementById('email');
    let phoneNumberInput = document.getElementById('phone-number');
    let bookRoomButton = document.getElementById('book-btn');
    let previewElement = document.getElementById('preview');
    let confirmationElement = document.getElementById('confirmation');
    

    let roomSizeElement = document.getElementById('preview-room-size');
    let timeSlotElement = document.getElementById('preview-time-slot');
    let fullNameElement = document.getElementById('preview-full-name');
    let emailElement = document.getElementById('preview-email');
    let phoneNumberElement = document.getElementById('preview-phone-number');


    bookRoomButton.addEventListener('click', onBookRoom)

    function onBookRoom(e)
    {
        e.preventDefault();
        if (roomSizeInput == "" || timeSlotInput == "" || fullNameInput == "" || emailInput == "" || phoneNumberInput == "")
        {
            return;
        }
        
        roomSizeElement.textContent = roomSizeInput.value;
        timeSlotElement.textContent = timeSlotInput.value;
        fullNameElement.textContent = fullNameInput.value;
        emailElement.textContent = emailInput.value;
        phoneNumberElement.textContent = phoneNumberInput.value;
        previewElement.style.display = 'block';
        

        bookRoomButton.disabled = true;
        
        roomSizeInput.value = '';
        timeSlotInput.value = '';
        fullNameInput.value = '';
        emailInput.value = '';
        phoneNumberInput.value = '';



    }

    let editButton = document.getElementById('edit-btn');
    editButton.addEventListener('click', onEdit);

    function onEdit()
    {
        roomSizeInput.value = roomSizeElement.textContent;
        timeSlotInput.value = timeSlotElement.textContent;
        fullNameInput.value = fullNameElement.textContent;
        emailInput.value = emailElement.textContent;
        phoneNumberInput.value = phoneNumberElement.textContent;

        bookRoomButton.disabled = false;
        previewElement.style.display = 'none';


    }

    let confirmButton = document.getElementById('confirm-btn');
    confirmButton.addEventListener('click', onConfirm);

    function onConfirm()
    {
        previewElement.style.display = 'none';
        confirmationElement.style.display = 'block';

    }

    let bookAnotherRoomButton = document.getElementById('back-btn');
    bookAnotherRoomButton.addEventListener('click', onBookAnotherRoom)

    function onBookAnotherRoom()
    {
        confirmationElement.style.display = 'none';
        bookRoomButton.disabled = false;
 
    }



}
  