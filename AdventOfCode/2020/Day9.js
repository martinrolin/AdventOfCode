const fs = require('fs');
var data;
try {
  data = fs.readFileSync('..\\Input\\2020\\day9.txt', 'utf8')
} catch (err) {
  console.error(err)
}
var input_array = data.split(/\n/).map(x=>parseInt(x));

for ([i,value] of input_array.entries()){

  if (i < 25)
    continue;
  var subArray = input_array.slice(i-25,i);
  
  var found = false;
  for (j = 0; j < subArray.length; j++){
    var a = value - subArray[j];
    if (subArray.includes(a))
      found = true;
  }
  if (!found){
    console.log("value : " + value);
    break;
  }
}

var data;
try {
  data = fs.readFileSync('..\\Input\\2020\\day9.txt', 'utf8')
} catch (err) {
  console.error(err)
}
var input_array = data.split(/\n/).map(x=>parseInt(x));

for (i = 0; i < input_array.length; i++){
  sum = 0;
  min = 10000000000000000000000000;
  max = -1;
  for(j = i; j < input_array.length; j++){
    sum += input_array[j];
    if(sum > 21806024)
      break;
    min = Math.min(input_array[j],min);
    max = Math.max(input_array[j],max);
    if (21806024 == sum){
      console.log("min: " + min + " max: " + max + " sum: " + (min+max));
      return;
    }
  }
}
