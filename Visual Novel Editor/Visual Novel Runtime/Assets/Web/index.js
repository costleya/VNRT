function appendSpan()
{
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

function setBackground(path)
{
    $("#scene").css("background-image", "url('" + path + "')")
}

function setDialogText(text)
{
    $("#dialog").html(text);
}

function setCharacter(sprite, xPos, yPos)
{
    var addedCharacter = document.createElement("img");
    addedCharacter.classList.add("characterImage");
    $(addedCharacter).attr("src", sprite);
    $(addedCharacter).css("height", 600);
    $(addedCharacter).css("width", 400);
    if (xPos)
    {
        $(addedCharacter).css("left", xPos);
    }
    if (yPos)
    {
        $(addedCharacter).css("margin-bottom", yPos);
    }
    $("#scene").append(addedCharacter);
}
