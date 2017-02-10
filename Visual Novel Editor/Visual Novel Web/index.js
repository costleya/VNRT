function loadGame(gameString)
{
    var game = JSON.parse(gameString);
    setBackground(game.Scenes[0].BackgroundImage);
    setDialogText(game.Scenes[0].Instances[0].Dialog.Text);
    setCharacter(game.Scenes[0].Instances[0].Characters[1].CharacterSprites[0].Path);
    setMusic(game.Scenes[0].BackgroundMusic);
}
var TextHelper = new textHelper();
function setBackground(path)
{
    document.getElementById("scene").style.backgroundImage = "url('" + path + "')";
}
function setMusic(path) {
    var audio = document.getElementById('audio');
    var source = document.getElementById('mp3Source');
    source.src = path;

    audio.load(); //call this to just preload the audio without playing
    audio.play(); //call this to play the song right away
}

function textHelper() { // constructor function
    this.cptLines = 0; // Public variable
}

function setDialogText(text)
{
    //Replace . ? !  by $1| To keep then in the split.
    var lines = text.replace(/([.?!])\s*(?=[A-Z])/g, "$1|").split("|");
    var array = [];

    lines.forEach(function (line) {
        if (line.length < 280)
        {
            array.push(line);
        }
        else
        {
            array.push(line.substring(0, line.indexOf(" ", 300)));
            array.push(line.substring(line.indexOf(" ", 300) + 1, line.length));
        }
    });

    $('#dialogBox').click(function () {
        if (TextHelper.cptLines != array.length)
        {
            $('#dialog').empty();
            var spans = '<span>' + array[TextHelper.cptLines].split('').join('</span><span>') + '</span>' + "<span class=\"blink\">|</span>";
            $(spans).hide().appendTo('.css-typing').each(function (i) {
                $(this).delay(20 * i).css({
                    display: 'inline',
                    opacity: 0
                }).animate({
                    opacity: 1
                }, 100);
            });
            TextHelper.cptLines++;
        }
    });  
}


function setCharacter(sprite)
{
    var addedCharacter = document.createElement("img");
    var src = document.createAttribute("src");
    src.nodeValue = sprite;
    addedCharacter.classList.add("characterImage");
    addedCharacter.attributes.setNamedItem(src);
   
    addedCharacter.addEventListener("dragstart", function (e)
    {
        e.preventDefault();
        return false;
    }, true);
    document.getElementById("scene").appendChild(addedCharacter);
}