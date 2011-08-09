/**
 * @fileOverview This file is a source which be used to create a counter
 * @author <a href="mailto:fogtower1979@gmail.com">Fog Tower</a>
 * @see <a href="http://www.fogtower.com">fogtower.com</a>
 * Version: 1.0.0
 */
 
 /**
 * Construct a namespace.
 * @namespace JSCounter
 */
JSCounter = {

};

/**
 * Construct a new JSCounter.NumberCounter.
 * @class Represents a JSCounter.NumberCounter.
 * @constructor
 * @example 
 * var myCounter = new JSCounter.NumberCounter("containerId");
 * @param {String} targetId The id of JSCounter.NumberCounter's container.
 * @param {Object} options The config parameters of JSCounter.NumberCounter.
 * @return A new instance of a JSCounter.NumberCounter.
 */
JSCounter.NumberCounter = function(container, options){
   /**
    * The id of JSCounter's container
    * @type String
    */
	this.container = container; 
	
	/**
    * The config parameters of JSCounter
    * @type Object
    */
	this.options = $.extend({

		/**
	    * Height of number
	    * @type string
	    * @default "30px"
	    */
        numberHeight: "30px",

		/**
	    * Width of number
	    * @type string
	    * @default "14px"
	    */
        numberWidth:"14px",

		/**
	    * Font Size of number
	    * @type string
	    * @default "25px"
	    */
        numberSize:"25px",
        	
		/**
	    * Whether auto run
	    * @type boolean
	    * @default false
	    */
        auto:false,
        	
		/**
	    * Whether auto increase
	    * @type boolean
	    * @default true
	    */
        increase:true,
        	
		/**
	    * Step of auto increase or decrease
	    * @type int
	    * @default 1
	    */
        step:1,

		/**
	    * Duration of animation (in milliseconds)
	    * @type int
	    * @default 1000
	    */
        speed:1000,

		/**
	    * Time between the end of the scroll and the beginning of the animation in milliseconds
	    * @type int
	    * @default 1000
	    */        	
        delay:1000,

		/**
	    * Default init number
	    * @type int
	    * @default 10000
	    */ 
        start:10000,

		/**
	    * The character in front of number
	    * @type string
	    * @default ""
	    */
	    pretoken:"",

		/**
	    * Whether show the comma in the number
	    * @type boolean
	    * @default true
	    */
        comma:true
    }, options || {});
	
};

/**
 * Render JSCounter.NumberCounter.
 * @public
 */
JSCounter.NumberCounter.prototype.render = function(){
	if(this.options.start < 0){
		this.minus = true;
		this._createDiv(-this.options.start);
	}else{
		this.minus = false;
		this._createDiv(this.options.start);
	}
	this.lastNumber = this.options.start;
	if(this.options.auto){
		this.run();
	}
};

/**
 * Run JSCounter.NumberCounter.
 * @public
 */
JSCounter.NumberCounter.prototype.run = function(){
	if(this.running){
		return;
	}
	this.running = true;
	this._run();
};

/**
 * Auto run JSCounter.NumberCounter.
 * @private
 */
JSCounter.NumberCounter.prototype._run = function(){
	if(this.options.increase){
		this.setNumber(this.lastNumber + this.options.step);
	}
	else{
		this.setNumber(this.lastNumber - this.options.step);
	}
	var othis = this;
	this.autoCounter = setTimeout(function(){othis._run();},this.options.delay);
};

/**
 * Stop auto running JSCounter.NumberCounter.
 * @public
 */
JSCounter.NumberCounter.prototype.stop = function(){
	this.running = false;
	clearTimeout(this.autoCounter);
};

/**
 * Create JSCounter.NumberCounter elements in the container.
 * @private
 */
JSCounter.NumberCounter.prototype._createDiv = function(number){
	var str = "";
	if(this.options.pretoken){
		str += "<div style='position:static;overflow:hidden;float:left;width:" + this.options.numberWidth
			+ ";height:" + this.options.numberHeight
			+ ";font-size:" + this.options.numberSize + ";'>" + this.options.pretoken + "</div>";
	}
	
	str += "<div id='" + this.container
		+ "-minus' style='position:static;overflow:hidden;float:left;width:" + this.options.numberWidth
		+ ";height:" + this.options.numberHeight
		+ ";font-size:" + this.options.numberSize;
	if(!this.minus){
		str += ";display:none";
	}
	str += ";'>-</div>";
	var positions = this._getPosition(number);
	var arr = [];
	var commaCount = 0;
	for(var i = 0; i < number.toString().length; i++){
		var div = "";
		if(this.options.comma){
			if(commaCount == 3){
				var commaDiv = "<div style='position:static;overflow:hidden;float:left;width:" + this.options.numberWidth
					+ ";height:" + this.options.numberHeight
					+ ";font-size:" + this.options.numberSize + ";'>,</div>";
				commaCount = 1;
				arr.push(commaDiv);
			}
			else{
				commaCount++;
			}
		}
		div = "<div style='position:relative;overflow:hidden;float:left;width:" + this.options.numberWidth
			+ ";height:" + this.options.numberHeight
			+ ";font-size:" + this.options.numberSize + ";'>"
			+ "<div id='" + this.container + "-number-" + i + "' style='position:relative;bottom:" + positions[i] + "px;'>";

		    for(var j = 9; j > -2; j--){
		    	if(j == -1){
			    	div += "<div style='height:" + this.options.numberHeight + ";font-size:" + this.options.numberSize + ";'></div>"
		    	}else{
			    	div += "<div style='height:" + this.options.numberHeight + ";font-size:" + this.options.numberSize + ";'>"
			    		+ j + "</div>"
		    	}
		    }
		 div += "</div></div>";
		 arr.push(div);
	}
	str += arr.reverse().join("");
	document.getElementById(this.container).innerHTML = str;
};

/**
 * Get the bottom's value of number.
 * @param {Number} number The number which will get the positions.
 * @private
 * @returns {Array} Every number's bottom value.
 */
JSCounter.NumberCounter.prototype._getPosition = function(number){
	var numbers = number.toString();
	var position = [];
	for(var i = numbers.length - 1; i > -1; i--){
		var numberPos = (9 - parseInt(numbers.charAt(i), 10)) * parseInt(this.options.numberHeight,10);
		position.push(numberPos);
	}
	return position;
};


/**
 * Set number to show.
 * @param {Number} number The number which will be set.
 * @public
 */
JSCounter.NumberCounter.prototype.setNumber = function(number){
	if(typeof number != "number"){
		alert("The input parameter is not a number.");
		return;
	}
	var minusDiv = document.getElementById(this.container + "-minus");
	var myNumber = number;
	if(number < 0){
		this.minus = true;
		myNumber = -number;
		minusDiv.style.display = "";
	}else{
		this.minus = false;
		minusDiv.style.display = "none";
	}
	if(myNumber.toString().length != this.lastNumber.toString().length){
		var str = "";
		for(var i = 0; i < myNumber.toString().length; i++){
			if(i == 0){
				str += "1";
			}else{
				if(this.options.increase){
					str += "9";
				}
				else{
					str += "0";
				}
			}
		}
		this._createDiv(parseInt(str,10));
		this.lastNumber = parseInt(str,10);
	}
	var positions = this._getPosition(myNumber);
	var lastNumberLength = this.lastNumber.toString().length;
	for(var i = 0; i < lastNumberLength; i++){
		var id = this.container + "-number-" + i;
		if(positions[i] || positions[i] == 0){
			$("#" + id).animate({bottom: positions[i]}, this.options.speed);
		}
		else{
			$("#" + id).animate({bottom: 10 * parseInt(this.options.numberHeight,10)}, this.options.speed);
		}
	}
	this.lastNumber = number;
};


/**
 * Construct a new TimeCounter.
 * @class Represents a TimeCounter.
 * @constructor
 * @example 
 * var myCounter = new JSCounter("containerId");
 * @param {String} targetId The id of JSCounter's container.
 * @param {Object} options The config parameters of JSCounter.
 * @return A new instance of a JSCounter.
 */
JSCounter.TimeCounter = function(container, options){
   /**
    * The id of JSCounter's container
    * @type String
    */
	this.container = container; 
	
	/**
    * The config parameters of JSCounter
    * @type Object
    */
	this.options = $.extend({

		/**
	    * Height of number
	    * @type string
	    * @default "30px"
	    */
        numberHeight: "30px",

		/**
	    * Width of number
	    * @type string
	    * @default "14px"
	    */
        numberWidth:"14px",

		/**
	    * Font Size of number
	    * @type string
	    * @default "25px"
	    */
        numberSize:"25px",
        	
		/**
	    * Whether auto run
	    * @type boolean
	    * @default false
	    */
        auto:false,
        	
		/**
	    * Whether auto increase
	    * @type boolean
	    * @default true
	    */
        increase:true,
        	
		/**
	    * Step of auto increase or decrease
	    * @type int
	    * @default 1
	    */
        step:1,

		/**
	    * Duration of animation (in milliseconds)
	    * @type int
	    * @default 1000
	    */
        speed:1000,

		/**
	    * Time between the end of the scroll and the beginning of the animation in milliseconds
	    * @type int
	    * @default 1000
	    */        	
        delay:1000,

		/**
	    * Default init number
	    * @type int
	    * @default 10000
	    */ 
        initHour:20,


		/**
	    * Default init number
	    * @type int
	    * @default 10000
	    */ 
        initMinute:59,


		/**
	    * The character in front of number
	    * @type string
	    * @default ""
	    */
	    initSecond:59,

		/**
	    * Whether show zero
	    * @type boolean
	    * @default true
	    */
	    showZero:true,

		/**
	    * Callbcak function when time is zero
	    * @type boolean
	    * @default true
	    */
	    finalFunction : null
    }, options || {});
	
};

/**
 * Render JSCounter.TimeCounter.
 * @public
 */
JSCounter.TimeCounter.prototype.render = function(){
	this._initTime(this.options.initHour, this.options.initMinute, this.options.initSecond);
	this._createDiv(this.lastHour, this.lastMinute, this.lastSecond);
	if(this.options.auto){
		this.run();
	}
};

/**
 * Init original time.
 * @private
 */
JSCounter.TimeCounter.prototype._initTime = function(hour, minute, second){
	if(hour == null || typeof hour =="undefined"){
		this.lastHour = null;
	}
	else if(typeof hour != "number" || hour < 0){
		this.lastHour = 0;
	}
	else{
		this.lastHour = hour;
	}
	
	if(minute == null || typeof minute =="undefined"){
		if(this.lastHour == null){
			this.lastMinute = null;
		}
		else{
			this.lastMinute = 0;
		}
	}
	else if(typeof minute != "number" || minute > 59 || minute < 0)
	{
		this.lastMinute = 0;
	}
	else{
		this.lastMinute = minute;
	}
	
	if(typeof second != "number" || second > 59 || second < 0){
		this.lastSecond = 0;
	}
	else{
		this.lastSecond = second;
	}
	
};

/**
 * Run JSCounter.TimeCounter.
 * @public
 */
JSCounter.TimeCounter.prototype.run = function(){
	if(this.running){
		return;
	}
	this.running = true;
	this._run();
};

/**
 * Auto run JSCounter.TimeCounter.
 * @private
 */
JSCounter.TimeCounter.prototype._run = function(){
	var time = this._getTime();
	if(time == null){
		this.stop();
		if(typeof this.options.finalFunction == "function"){
			this.options.finalFunction();
		}
		return;
	}
	this.setTime(time.hour, time.minute, time.second);
	var othis = this;
	this.autoCounter = setTimeout(function(){othis._run();},this.options.delay);
};

/**
 * Get auto run time.
 * @private
 * @returns {Object} auto run time.
 */
JSCounter.TimeCounter.prototype._getTime = function(){
	var time = {};
	var hour = this.lastHour;
	var minute = this.lastMinute;
	var second = this.lastSecond;
	if(this.options.increase){
		second++;
		if(second == 60){
			second = 0;
			minute++;
		}
		if(minute == 60){
			minute = 0;
			hour++;
		}
	}
	else{
		second--;
		if(second == -1){
			second = 59;
			minute--;
		}
		if(minute == -1){
			minute = 59;
			hour--;
		}
		if(hour < 0){
			return null;
		}
	}
	
	time.second = second;
	time.minute = minute;
	time.hour = hour;
	return time;
};


/**
 * Stop auto running JSCounter.TimeCounter.
 * @public
 */
JSCounter.TimeCounter.prototype.stop = function(){
	this.running = false;
	clearTimeout(this.autoCounter);
};


/**
 * Create JSCounter.TimeCounter elements in the container.
 * @private
 */
JSCounter.TimeCounter.prototype._createDiv = function(hour, minute, second){
	var str = "";
	var housPositions = this._getPosition(hour);
	this.hourLength = housPositions.length;
	for(var i = 0; i < housPositions.length; i++){
		str += "<div style='position:relative;overflow:hidden;float:left;width:" + this.options.numberWidth
		+ ";height:" + this.options.numberHeight
		+ ";font-size:" + this.options.numberSize + ";'>"
		+ "<div id='" + this.container + "-hour-" + i + "' style='position:relative;bottom:" + housPositions[i] + "px;'>";
	    for(var j = 9; j > -1; j--){
		    str += "<div style='height:" + this.options.numberHeight + ";font-size:" + this.options.numberSize + ";'>"
		    		+ j + "</div>"
	    }
	    str += "</div></div>";
	}
	if(str){
		str += "<div style='position:static;overflow:hidden;float:left;width:" + this.options.numberWidth
			+ ";height:" + this.options.numberHeight
			+ ";font-size:" + this.options.numberSize + ";'>:</div>";
	}
	var minutePositions = this._getPosition(minute);
	for(var i = 0; i < minutePositions.length; i++){
		str += "<div style='position:relative;overflow:hidden;float:left;width:" + this.options.numberWidth
		+ ";height:" + this.options.numberHeight
		+ ";font-size:" + this.options.numberSize + ";'>"
		+ "<div id='" + this.container + "-minute-" + i + "' style='position:relative;bottom:" + minutePositions[i] + "px;'>";
	    for(var j = 9; j > -1; j--){
		    str += "<div style='height:" + this.options.numberHeight + ";font-size:" + this.options.numberSize + ";'>"
		    		+ j + "</div>"
	    }
	    str += "</div></div>";
	}
	if(str){
		str += "<div style='position:static;overflow:hidden;float:left;width:" + this.options.numberWidth
			+ ";height:" + this.options.numberHeight
			+ ";font-size:" + this.options.numberSize + ";'>:</div>";
	}
	var secondPositions = this._getPosition(second);
	for(var i = 0; i < secondPositions.length; i++){
		str += "<div style='position:relative;overflow:hidden;float:left;width:" + this.options.numberWidth
		+ ";height:" + this.options.numberHeight
		+ ";font-size:" + this.options.numberSize + ";'>"
		+ "<div id='" + this.container + "-second-" + i + "' style='position:relative;bottom:" + secondPositions[i] + "px;'>";
	    for(var j = 9; j > -1; j--){
		    str += "<div style='height:" + this.options.numberHeight + ";font-size:" + this.options.numberSize + ";'>"
		    		+ j + "</div>"
	    }
	    str += "</div></div>";
	}
	document.getElementById(this.container).innerHTML = str;
};


/**
 * Get the bottom's value of number.
 * @param {Number} number The number which will get the positions.
 * @private
 * @returns {Array} Every number's bottom value.
 */
JSCounter.TimeCounter.prototype._getPosition = function(number){
	var position = [];
	if(number == null){
		return position;
	}
	var numbers = number.toString();
	if(this.options.showZero && numbers.length < 2){
		numbers = "0" + numbers;
	}
	for(var i = 0; i < numbers.length; i++){
		var numberPos = (9 - parseInt(numbers.charAt(i), 10)) * parseInt(this.options.numberHeight,10);
		position.push(numberPos);
	}
	return position;
};

/**
 * Set time to show.
 * @param {Number} hour The hour which will be set.
 * @param {Number} minute The minute which will be set.
 * @param {Number} second The second which will be set.
 * @public
 */
JSCounter.TimeCounter.prototype.setTime = function(hour, minute, second){
	if(typeof hour != "number" || typeof minute != "number" || typeof second != "number"){
		alert("The input parameter is not a number.");
		return;
	}
	var lastTimeString = this.lastHour.toString() + this.lastMinute.toString() + this.lastSecond.toString();
	this._initTime(hour, minute, second);
	if(!this.options.showZero){
		var tempstr1 = this.lastHour.toString() + this.lastMinute.toString() + this.lastSecond.toString();
		if(tempstr1.length != lastTimeString.length){
			var tempHour = "";
			var tempMinute = 1;
			var tempSecond = 1;
			for(var i = 0; i < this.lastHour.toString().length; i++){
				if(i == 0){
					tempHour += "1";
				}else{
					if(this.options.increase){
						tempHour += "9";
					}
					else{
						tempHour += "0";
					}
				}
			}
			tempHour = parseInt(tempHour,10);
			if(this.lastMinute > 9){
				tempMinute = 10
			}
			if(this.lastSecond > 9){
				tempSecond = 10
			}
			this._createDiv(tempHour, tempMinute, tempSecond);
		}
	}
	var hourPosition = this._getPosition(this.lastHour);
	if(this.hourLength > hourPosition.length && this.options.showZero){
		hourPosition = hourPosition.reverse();
		var count = 0;
		for(var i = this.hourLength - 1; i > -1; i--){
			var id = this.container + "-hour-" + i;
			if(hourPosition[count]){
				$("#" + id).animate({bottom: hourPosition[count]}, this.options.speed);
			}
			else{
				$("#" + id).animate({bottom: 9 * parseInt(this.options.numberHeight,10)}, this.options.speed);
			}
			count++;
		}
	}else{
		for(var i = 0; i < hourPosition.length; i++){
			var id = this.container + "-hour-" + i;
			$("#" + id).animate({bottom: hourPosition[i]}, this.options.speed);
		}
	}
	var minutePosition = this._getPosition(this.lastMinute);
	for(var i = 0; i < minutePosition.length; i++){
		var id = this.container + "-minute-" + i;
		$("#" + id).animate({bottom: minutePosition[i]}, this.options.speed);
	}
	var secondPosition = this._getPosition(this.lastSecond);
	for(var i = 0; i < secondPosition.length; i++){
		var id = this.container + "-second-" + i;
		$("#" + id).animate({bottom: secondPosition[i]}, this.options.speed);
	}
	

};











