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

function setBackground(path)
{
    $("#container").css("background-image", "url('" + path + "')")
}

function setDialogText(text)
{
    $("#dialogBox").html(text);
}

function setCharacter(xPos, yPos, sprite)
{
    var addedCharacter = document.createElement("img");
    $(addedCharacter).attr("src", sprite);
    //   $(addedCharacter).css("position", "absolute");
    //   $(addedCharacter).css("left", xPos);
    //   $(addedCharacter).css("top", yPos);
    //$(addedCharacter).css("text-align","center");
    $(addedCharacter).css("height", 600);
    $(addedCharacter).css("width", 400);
    $("#scene").append(addedCharacter);
}
