var config=require('./config.json')
module.exports = function () {
    mode:'production';
    var greet = document.createElement('div');
    greet.textContent = config.greetText;//"各位好";
    return greet;
}


