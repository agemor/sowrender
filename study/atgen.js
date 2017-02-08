var fs = require('fs');

var models = ["N100H", "X100L", "A10", "N10", "W20", "Cast-Fi 7", "FLOW"];
var finish = ["Silver", "Black"];
var capacity = ["2TB", "4TB", "6TB", "8TB", "12TB"];


String.prototype.hashCode = function() {
  var hash = 0, i, chr, len;
  if (this.length === 0) return hash;
  for (i = 0, len = this.length; i < len; i++) {
    chr   = this.charCodeAt(i);
    hash  = ((hash << 5) - hash) + chr;
    //hash |= 0;
  }
  return hash;
};


var names = ["RY",
    "PATRICIA",
    "LINDA",
    "BARBARA",
    "ELIZABETH",
    "JENNIFER",
    "MARIA",
    "SUSAN",
    "MARGARET",
    "DOROTHY",
    "LISA",
    "NANCY",
    "KAREN",
    "BETTY",
    "HELEN",
    "SANDRA",
    "DONNA",
    "CAROL",
    "RUTH",
    "SHARON",
    "MICHELLE",
    "LAURA",
    "SARAH",
    "KIMBERLY",
    "DEBORAH",
    "JESSICA",
    "SHIRLEY",
    "CYNTHIA",
    "ANGELA",
    "MELISSA",
    "BRENDA",
    "AMY"
];

var countries = ["Afghanistan","Albania","Algeria","Andorra","Angola","Anguilla","Antigua &amp; Barbuda","Argentina","Armenia","Aruba","Australia","Austria","Azerbaijan","Bahamas","Bahrain","Bangladesh","Barbados","Belarus","Belgium","Belize","Benin","Bermuda","Bhutan","Bolivia","Bosnia &amp; Herzegovina","Botswana","Brazil","British Virgin Islands","Brunei","Bulgaria","Burkina Faso","Burundi","Cambodia","Cameroon","Cape Verde","Cayman Islands","Chad","Chile","China","Colombia","Congo","Cook Islands","Costa Rica","Cote D Ivoire","Croatia","Cruise Ship","Cuba","Cyprus","Czech Republic","Denmark","Djibouti","Dominica","Dominican Republic","Ecuador","Egypt","El Salvador","Equatorial Guinea","Estonia","Ethiopia","Falkland Islands","Faroe Islands","Fiji","Finland","France","French Polynesia","French West Indies","Gabon","Gambia","Georgia","Germany","Ghana","Gibraltar","Greece","Greenland","Grenada","Guam","Guatemala","Guernsey","Guinea","Guinea Bissau","Guyana","Haiti","Honduras","Hong Kong","Hungary","Iceland","India","Indonesia","Iran","Iraq","Ireland","Isle of Man","Israel","Italy","Jamaica","Japan","Jersey","Jordan","Kazakhstan","Kenya","Kuwait","Kyrgyz Republic","Laos","Latvia","Lebanon","Lesotho","Liberia","Libya","Liechtenstein","Lithuania","Luxembourg","Macau","Macedonia","Madagascar","Malawi","Malaysia","Maldives","Mali","Malta","Mauritania","Mauritius","Mexico","Moldova","Monaco","Mongolia","Montenegro","Montserrat","Morocco","Mozambique","Namibia","Nepal","Netherlands","Netherlands Antilles","New Caledonia","New Zealand","Nicaragua","Niger","Nigeria","Norway","Oman","Pakistan","Palestine","Panama","Papua New Guinea","Paraguay","Peru","Philippines","Poland","Portugal","Puerto Rico","Qatar","Reunion","Romania","Russia","Rwanda","Saint Pierre &amp; Miquelon","Samoa","San Marino","Satellite","Saudi Arabia","Senegal","Serbia","Seychelles","Sierra Leone","Singapore","Slovakia","Slovenia","South Africa","South Korea","Spain","Sri Lanka","St Kitts &amp; Nevis","St Lucia","St Vincent","St. Lucia","Sudan","Suriname","Swaziland","Sweden","Switzerland","Syria","Taiwan","Tajikistan","Tanzania","Thailand","Timor L'Este","Togo","Tonga","Trinidad &amp; Tobago","Tunisia","Turkey","Turkmenistan","Turks &amp; Caicos","Uganda","Ukraine","United Arab Emirates","United Kingdom","Uruguay","Uzbekistan","Venezuela","Vietnam","Virgin Islands (US)","Yemen","Zambia","Zimbabwe"];

var count = 1000;

// print process.argv
process.argv.forEach(function (val, index, array) {
  count = Number(val);
});


var buffer = count + "\n";

for (var i = 0; i < count; i++) {
    var name = names[Math.floor(Math.random() * names.length)];
    buffer += name + ", ";
    buffer += models[Math.floor(Math.random() * models.length)] + " (";
    buffer += finish[Math.floor(Math.random() * finish.length)] + ", ";
    buffer += capacity[Math.floor(Math.random() * capacity.length)] + "), ";
    buffer += Math.floor(Math.random() * 8 - 3) + ", ";
    buffer += countries[Math.floor(Math.random() * countries.length)] + ", ";
    buffer += Math.abs(name.hashCode()) + "\n";

}

//console.log(buffer);

fs.writeFile("./output.txt", buffer, function(err) {
    if(err) {
        return console.log(err);
    }

    console.log("Sales data were generated.");
}); 