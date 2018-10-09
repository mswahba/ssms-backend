export default () => {
  // generate random integer between min and max values
  Number.between = function(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
  };
  // generate a random string array
  Array.random = function({len = 10, count = 10, unique = false}) {
    let _currString,
        _stringOpts = {
          upper: true,
          numbers: true,
          len: len
         },
        _result = [];

    for (let i = 0; i < count; i++) {
      _currString = String.random(_stringOpts);
      if (unique) {
        while ( _result.includes(_currString) )
          _currString = String.random(_stringOpts);
      }
      _result.push(_currString);
    }

    return _result;
  }
  // generate a random string
  String.random = function({ lower, upper, numbers, symbols, len }) {
    let _base = "",
        _allStrings = {
          lower: "abcdefghijklmnopqrstuvwxyz",
          upper: "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
          numbers: "0123456789"
        },
        _currChar = "",
        _prevChar = "",
        _result = "";
    if(lower)
      _base += _allStrings.lower;
    if(upper)
      _base += _allStrings.upper;
    if(numbers)
      _base += _allStrings.numbers;
    if(symbols)
      _base += symbols;
    for(var i=0;i<len;i++) {
      // get the current random character but not equal the previous one
      do {
          _currChar = _base.charAt(Number.between(0,_base.length-1));
      } while (_prevChar === _currChar);
      // append it to the generated string
      _result += _currChar;
      // put the current in the previous for the next character
      _prevChar = _currChar;
    }
    return _result;
  };
  // return full datetime string
  Date.prototype.toString = function(format = "dd/mm/yyyy 00:00:00 AM") {
    let separator = "/",
      day,
      month;
    switch (format) {
      case "dd/mm/yyyy 00:00:00 AM":
        let parts = this.toLocaleString()
          .split(",")
          .join("")
          .split("/");
        day = (+parts[1] > 9 ? "" : "0") + parts[1];
        month = (+parts[0] > 9 ? "" : "0") + parts[0];
        return [day, month, parts[2]].join("/");
      case "dd-mm-yyyy":
        separator = "-";
      case "dd/mm/yyyy":
        day = this.getDate();
        day = (day > 9 ? "" : "0") + day;
        month = this.getMonth() + 1;
        month = (month > 9 ? "" : "0") + month;
        return [day, month, this.getFullYear()].join(separator);
      case "yyyy-mm-dd":
        separator = "-";
      case "yyyy/mm/dd":
        day = this.getDate();
        day = (day > 9 ? "" : "0") + day;
        month = this.getMonth() + 1;
        month = (month > 9 ? "" : "0") + month;
        return [this.getFullYear(), month, day].join(separator);
    }
  };
  // return the duration from now till that date in [years days hours minutes seconds] format
  Date.prototype.duration = function(format = "d") {
    // each time unit relavant to seconds used to do units calc
    const readaleFormat = (val, unit) =>
        (val += val > 1 ? " " + unit + "s" : " " + unit),
      shortFormat = (val, unit) => (val += " " + unit + "(s)"),
      leadingZero = val => (val < 10 ? "0" + val : val),
      time = {
        year: 31536000,
        day: 86400,
        hour: 3600,
        minute: 60,
        second: 1
      };
    // get the diffs between target date and now in seconds then add two hours [Cairo time]
    let seconds =
        this.getTime() / 1000 - new Date().getTime() / 1000 + time.hour * 2,
      val = "",
      lastUnit = "",
      result = [];
    // return the default format [numbers only]
    if (format === "d") {
      return Object.keys(time)
        .map(unit => {
          if (seconds >= time[unit]) {
            val = Math.floor(seconds / time[unit]);
            seconds = seconds % time[unit];
            return leadingZero(val);
          } else {
            return "00";
          }
        })
        .join(":");
    } else {
      for (let unit of Object.keys(time)) {
        if (seconds >= time[unit]) {
          val = Math.floor(seconds / time[unit]);
          seconds = seconds % time[unit];
          result.push(
            format === "r" ? readaleFormat(val, unit) : shortFormat(val, unit)
          );
        }
      }
      // get the last unit
      lastUnit = result.pop();
      // build the result string from the result array and lastUnit
      return result.length ? result.join(", ") + " and " + lastUnit : lastUnit;
    }
  };
  // add or substract date units [year - month - week - day - hour - minute - second]
  Date.prototype.add = function(value = 1, unit = 'day') {
    // datetime units represented by milliseconds [used to apply changes]
    const units = {
      year: 31536000000,  // 365 days
      month: 2592000000,  // 30 days
      week: 604800000,    // 7 days
      day: 86400000,
      hour: 3600000,
      minute: 60000,
      second: 1000
    };
    // change the datetime value
    this.setTime( this.getTime() + (units[unit]*value) );
    // return it after change
    return this;
  }
  // compare date
  Date.prototype.compare = function(op,d1,d2) {
    if (!op || !d1)
      return 'must provide comparison operator and/or date value';
    switch(op) {
      case '==':
        return this == d1;
      case '>=':
        return this >= d1;
      case '<=':
        return this <= d1;
      case '>':
        return this > d1;
      case '<':
        return this < d1;
      case 'between':
        return (d2)
                ? this >= d1 && this <= d2
                : 'must provide second date value';
      default:
        return 'invalid comparison operator !!!'
    }
  }
  // get time with milliseconds
  Date.prototype.getFullTime = function() {
    let hours = this.getHours();
    hours = (hours < 10)? '0'+hours : hours;
    let minutes = this.getMinutes();
    minutes = (minutes < 10)? '0'+minutes : minutes;
    let seconds = this.getSeconds();
    seconds = (seconds < 10)? '0'+seconds : seconds;
    let milliseconds = this.getMilliseconds();
    milliseconds = (milliseconds < 10)
                      ? '00'+milliseconds
                      : (milliseconds < 100)
                        ? '0'+milliseconds
                        : milliseconds;
    const period = this.toLocaleTimeString().slice(-2);
    return `${hours}:${minutes}:${seconds}.${milliseconds} ${period}`;
  }
  // randomize sort an array
  Array.prototype.randomize = function(count) {
    if (this.length <= 1) return this;
    let index,
      indexes = [],
      len = count ? count : this.length;
    // generate random index
    // if not in the indexes add it
    // do this till the indexes length equal to array length
    do {
      index = Number.between(0, this.length - 1);
      if (!indexes.includes(index)) indexes.push(index);
    } while (indexes.length < len);
    // do the shuffle
    return indexes.map(index => this[index]);
  };
  Array.prototype.flatten = function() {
    this.reduce((a, b) => a.concat(Array.isArray(b) ? b.flatten() : b), []);
  };
  // randomize sort an array
  Array.prototype.shuffle = function() {
    if (this.length < 2) return this;
    this.sort(() => Math.random() - 0.5);
  };
  // clean an array [remove null or undifined or empty string or empty object]
  Array.prototype.clean = function() {
    return this.filter( item => {
      if (typeof item === 'object')
        return item !== null && Object.keys(item).length > 0
      else
        return item !== "" && item !== undefined
    })
  };
  // split an array to group of chunks of fixed length
  Array.prototype.chunks = function(chunkSize) {
    if (chunkSize >= this.length) return this;
    let result = [],
      len = this.length;
    for (let i = 0; i < len; i += chunkSize)
      result.push(this.slice(i, i + chunkSize));
    return result;
  };
  // remove any duplicated values from array
  Array.prototype.unique = function(keyName) {
    let result = [];
    if (keyName)
      this.forEach(item => {
        if (item[keyName] && !result.includes(item[keyName]))
          result.push(item[keyName]);
      });
    else
      this.forEach(item => {
        if (item !== "" && !result.includes(item))
          result.push(item);
      });

    this.length = 0;
    this.push(...result);
    return this;
  };
  // return random item(s) from array
  Array.prototype.random = function(count = 1) {
    let randIndex = 0;
    if (count === 1) {
      randIndex = Number.between(0, this.length - 1);
      return this[randIndex];
    }
    if (count >= this.length) return this.shuffle();
    let indexes = [];
    for (let i = 0; i < count; i++) {
      do {
        randIndex = Number.between(0, this.length - 1);
      } while (indexes.includes(randIndex));
      indexes.push(randIndex);
    }
    return indexes.map(index => this[index]);
  };
  // group an array of object by specified field values
  Array.prototype.groupBy = function(field) {
    let groups = {},
        key;
    if(!field)
      return groups;
    this.forEach( item => {
      if(item[field]) {
        key = item[field];
        if(!Object.keys(item).includes(key))
          groups[key] = [];
        groups[key].push(item);
      }
    });
    return groups;
  }
  // title case a string
  String.prototype.toTitleCase = function() {
    let str = this.toLowerCase();
    return str.charAt(0).toUpperCase() + str.slice(1);
  };
  // return fixed length slice from a string
  String.prototype.chunks = function(chunkLength) {
    if (chunkLength >= this.length)
      return this;
    let result = [],
        len = this.length;
    for (var i = 0; i < len; i += chunkLength)
      result.push(this.substring(i, i + chunkLength));
    return result;
  };
  // convert the date string to date object - it assume date string in dd/mm/yyyy
  // if format is false then assume string in yyyy/mm/dd or mm/dd/yyyy
  String.prototype.toDate = function(format = true) {
    let str = this;
    if (format) {
      let parts = this.split("/");
      str = [parts[1], parts[0], parts[2]].join("/");
    }
    return new Date(str);
  };
  // get querystring object from URL
  String.prototype.query = function() {
    if(this.indexOf('?') === -1)
      return 'there is no querystring !!!';
    let qStr = this.split('?')[1];
    let qString = qStr.split('&');
    return qString.reduce( (obj, item) => {
            const [ key, value ] = item.split('=');
            obj[key] = value;
            return obj;
          }, {});
  };
  // convert Bascal/camel case to Upper Case with Underscore in between words
  String.prototype.toUpperWithUnderscore = function() {
    return (
      this.split('')
       .map( (c,i) => (i>0 && c === c.toUpperCase()) ? `_${c}`: c )
       .join('')
       .toUpperCase()
    )
  }
  // test alphabetical letters for [EN - AR]
  String.prototype.alpha = function(lang) {
    const ar_alpha = /^([\u0600-\u06ff ]|[\u0750-\u077f ]|[\ufb50-\ufbc1 ]|[\ufbd3-\ufd3f ]|[\ufd50-\ufd8f ]|[\ufd92-\ufdc7 ]|[\ufe70-\ufefc ]|[\ufdf0-\ufdfd ])*$/g,
          en_alpha = /^[a-zA-Z ]+$/;
    switch(lang) {
      case 'en':
        return en_alpha.test(this);
      case 'ar':
        return ar_alpha.test(this);
      default:
        return ( en_alpha.test(this) || ar_alpha.test(this) );
    }
  }
};