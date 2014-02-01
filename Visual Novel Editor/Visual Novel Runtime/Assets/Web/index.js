function appendSpan() {
    var addedSpan = document.createElement("span");
    addedSpan.innerHTML = "This was added";
    addedSpan.style.color = "blue";
    document.getElementById("container").appendChild(addedSpan);
    window.external.notify("I added");
}

function appendMore()
{
    var addedSpan = document.createElement("span");
    addedSpan.innerHTML = "This was added... again";
    addedSpan.style.color = "red";
    document.getElementById("container").appendChild(addedSpan);
    window.external.notify("So it worked?!");
}

function recieveCommand(command, args)
{

}
