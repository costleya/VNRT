function loadGame(gameString)
{
    var game = JSON.parse(gameString);
    setBackground(game.Scenes[0].BackgroundImage);
    setDialogText(game.Scenes[0].Instances[0].Dialog.Text);
    setCharacter(game.Scenes[0].Instances[0].Characters[0].CharacterSprites[0].Path, "45%");
}

function setBackground(path)
{
    document.getElementById("scene").style.backgroundImage = "url('" + path + "')";
}

function setDialogText(text)
{
    document.getElementById("dialog").innerHTML = text;
}

function setCharacter(sprite, xPos, yPos)
{
    var addedCharacter = document.createElement("img");
    var src = document.createAttribute("src");
    var height = document.createAttribute("height");
    var width = document.createAttribute("width");
    src.nodeValue = sprite;
    height.nodeValue = 600;
    width.nodeValue = 400;
    addedCharacter.classList.add("characterImage");
    addedCharacter.attributes.setNamedItem(src);
    addedCharacter.attributes.setNamedItem(height);
    addedCharacter.attributes.setNamedItem(width);
    if (xPos)
    {
        addedCharacter.style.left = xPos;
    }
    if (yPos)
    {
        addedCharacter.style.marginBottom = yPos;
    }
    addedCharacter.addEventListener("dragstart", function ()
    {
        return false;
    }, false);
    document.getElementById("scene").appendChild(addedCharacter);
}