/*

Based on class Slideshow by Aeron Glemann, <http://electricprism.com/aeron/slideshow>.

*/

JaSlideshowClass = new Class({

	initialize: function(options) {
		
		this.options = options;

		if(!Cookie.get("JASLIDESHOWPLAY")){ Cookie.set("JASLIDESHOWPLAY", this.options.play, {duration: 1}); }

		this.play = Cookie.get("JASLIDESHOWPLAY")=='play'?1:0;

		if (this.options.images.length <= 1) { return; }

		if (this.options.pan != 'rand') {

			if (isNaN(this.options.pan.toInt()) || this.options.pan.toInt() < 0 || this.options.pan.toInt() > 100) { this.options.pan = 0; }

		}

		if (this.options.zoom != 'rand') {

			if (isNaN(this.options.zoom.toInt()) || this.options.zoom.toInt() < 0 || this.options.zoom.toInt() > 100) { this.options.zoom = 0; }

		}

		this.elementdiv = $('ja-slideshow-case');

		this.bardiv = $('ja-slidebar');

		this.image = img = $E('img', this.elementdiv);

		this.fx = [];

		this.start();

	},



	start: function() {

		this.elementdiv.setHTML('');

		this.image.setStyles({display: 'block', position: 'absolute', left: '0', top: '0', zIndex: 1});

		this.image.injectInside(this.elementdiv);

		this.setSize();

		this.elementdiv.setStyles({display: 'block', position: 'relative', width: this.width + 'px'});

		this.div = new Element('div');

		this.div.setStyles({display: 'block', height: (this.height + 'px'), overflow: 'hidden', position: 'relative', width: (this.width + 'px')});

		this.div.injectInside(this.elementdiv);

		this.image.injectInside(this.div);

		if (this.options.captions)
		{
			this.image.setProperty('alt', this.options.captions[0]);
			this.image.setProperty('title', this.options.captions[0]);
		}

		
		if (this.options.urls) {
			this.image.url = this.options.urls[0];
			this.image.style.cursor = "pointer";
			this.image.onclick = function() {
				location.href = this.url;
			}
		}

		this.imageAF = this.image.clone();
		this.imageAF.setStyle('opacity', 0);
		this.imageAF.injectAfter(this.image);
		if (this.options.navigation) { this.navigation(); }

		if ($type(this.options.captions) == 'array') {
			this.p = new Element('div');
			this.p.className = "description";
			this.p.setOpacity(0.75);
			if (!this.options.captions[0]) { this.p.className = "description-hidden"; }
			this.p.setHTML(this.options.captions[0]);
			this.p.injectInside(this.elementdiv);
		}



		this.direction = 'left';
		this.current = [1, 1];
		this.timer = (this.timer) ? [0] : [(new Date).getTime() + this.options.duration[1], 0];

		this.loader = new Image();
		this.loader.src = this.options.url + this.options.images[this.current[0]].trim();

		if (this.play) this.preload();
	},



	setSize: function () {
		obj = this.image.getCoordinates();
		this.height = ((this.options.height) ? this.options.height : obj['height']);
		this.width = ((this.options.width) ? this.options.width : obj['width']);
	},



	resize: function () {
		dh = this.height / this.loader.height;
		dw = this.width / this.loader.width;
		n = (dw > dh) ? dw : dh;
		if (this.options.resize) { img.setStyles({height: Math.ceil(this.loader.height * n) + 'px', width: Math.ceil(this.loader.width * n) + 'px'}); }
	},



	preload: function(fast) {
		
		if (this.loader.complete && ((new Date).getTime() > this.timer[0])) {

			img = (this.current[1] % 2) ? this.imageAF : this.image;

			img.setStyles({height: 'auto', opacity: 0, width: 'auto', zIndex: this.current[1]});
			//check	
			img.setProperty('src', this.loader.src);

			if (this.options.captions)
			{
				img.setProperty('alt', this.options.captions[this.current[0]]);
				img.setProperty('title', this.options.captions[this.current[0]]);
			}

			
			
			if (this.options.urls) {
				img.url = this.options.urls[this.current[0]];
				img.style.cursor = "pointer";
				img.onclick = function() {
					location.href = this.url;
				}
			} else {
				img.url = "";
				img.style.cursor = "";
				img.onclick = function() { }
			}

			this.resize();

			if (fast) {
				img.setStyles({left: '0px', opacity: 1, top: '0px'});
				if ($type(this.options.captions) == 'array') { this.p.setHTML(this.options.captions[this.current[0]]).setStyle('opacity', 1); }
				return this.loaded();

			}

			this.fx = [];

			if ($type(this.options.captions) == 'array') {
				fn = function(i) {
					if (this.options.captions && this.options.captions[i]) { this.p.className = "description"; this.p.setHTML(this.options.captions[i]); }
					else{ this.p.setHTML(''); this.p.className = "description-hidden"; }
					fx = new Fx.Style(this.p, 'opacity');
					fx.start(0, 0.75);
					this.fx.push(fx);
				}.pass(this.current[0], this);



				fx = new Fx.Style(this.p, 'opacity', {onComplete: fn});

				fx.start(1, 0);

				this.fx.push(fx);

			}



			if (this.options.type.test(/push|wipe/)) {

				img.setStyles({left: 'auto', right: 'auto'});

				img.setStyle(this.direction, this.width + 'px');

				img.setStyle('opacity', 1);



				if (this.options.type == 'wipe') {

					fx = new Fx.Style(img, this.direction, {duration: this.options.duration[0], transition: this.options.transition, onComplete: this.complete.bind(this)});

					fx.start(this.width, 0);

					this.fx.push(fx);

				}

				else {

					arr = [img, ((this.current[1] % 2) ? this.image : this.imageAF)];



					p0 = {};

					p0[this.direction] = [this.width, 0];

					p1 = {};

					p1[this.direction] = [0, (this.width * -1)];



					if (arr[1].getStyle(this.direction) == 'auto') {

						x = this.width - arr[1].getStyle('width').toInt();



						arr[1].setStyle(this.direction, x + 'px');

						arr[1].setStyle(((this.direction == 'left') ? 'right' : 'left'), 'auto');



						p1[this.direction] = [x, (this.width * -1)];

					}



					fx = new Fx.Elements(arr, {duration: this.options.duration[0], transition: this.options.transition, onComplete: this.complete.bind(this)});

					fx.start({'0': p0, '1': p1});

					this.fx.push(fx);

				}



			}

			else {

				img.setStyles({left: 'auto', top: 'auto', right: 'auto', bottom: 'auto'});

				arr = ['left top', 'right top', 'left bottom', 'right bottom'][this.current[1] % 4].split(' ');
				if((this.options.type).test(/zoom|combo/)) {
					arr.each(function(p) { img.setStyle(p, 0); });
				}

				zoom = ((this.options.type).test(/zoom|combo/)) ? this.zoom() : {};
				pan = ((this.options.type).test(/pan|combo/)) ? this.pan() : {};

				fx = new Fx.Style(img, 'opacity', {duration: this.options.duration[0]});
				fx.start(0, 1);
				this.fx.push(fx);

				fx = new Fx.Styles(img, {duration: (this.options.duration[0] + this.options.duration[1]), transition: Fx.Transitions.linear, onComplete: this.complete.bind(this)});
				fx.start(Object.extend(zoom, pan));

				this.fx.push(fx);

			}



			this.loaded();

		}

		else { this.timeout = this.preload.delay(100, this); }

	},



	complete: function() {

		if (!this.play) $clear(this.timeout);

	},



	loaded: function() {

		if (this.ul) {

			anchors = $ES('a[name]', this.ul);

			anchors.each(function(a, i) {

				if (i == this.current[0]) { a.addClass(this.options.classes[2]); }

				else { a.removeClass(this.options.classes[2]); }

			}, this);

		}



		this.direction = 'left';

		this.current[0] = (this.current[0] == this.options.images.length - 1) ? 0 : this.current[0] + 1;

		this.current[1]++;

		this.timer[0] = (new Date).getTime() + this.options.duration[1] + ((this.options.type.test(/fade|push|wipe/)) ? this.options.duration[0] : 0);

		this.timer[1] = (new Date).getTime() + this.options.duration[0];



		this.loader = new Image();

		//this.loader.src = 'http://localhost/1.5/edenite/' + this.options.url + this.options.images[this.current[0]].trim();
		//alert(this.siteurl);
		this.loader.src = this.options.siteurl + this.options.url + this.options.images[this.current[0]].trim();
		//alert(this.options.url);


		this.preload();

	},



	zoom: function() {

		z = (this.options.zoom == 'rand') ? Math.random() + 1 : (this.options.zoom.toInt() / 100.0) + 1;



		eh = Math.ceil(this.loader.height * n);

		ew = Math.ceil(this.loader.width * n);



		sh = parseInt(eh * z);

		sw = parseInt(ew * z);



		return {height: [sh, eh], width: [sw, ew]};

	},



	pan: function() {

		p = (this.options.pan == 'rand') ? Math.random() : Math.abs((this.options.pan.toInt() / 100.0) - 1);



		ex = (this.width - img.width);

		ey = (this.height - img.height);



		sx = parseInt(ex * p);

		sy = parseInt(ey * p);



		obj = {};



		if (dw > dh) { obj[arr[1]] = [sy, ey] }

		else { obj[arr[0]] = [sx, ex]; }



		return obj;

	},



	navigation: function() {

		this.ul = new Element('ul');

		if (this.options.navigation.test(/arrows|number/)) {

			li = new Element('li');

			a = new Element('a');

			a.addClass(this.options.classes[0]);

			a.innerHTML = '&laquo;';

			a.onclick = function() {

				if (this.options.navigation.test(/fast/) || (new Date).getTime() > this.timer[1]) {

					$clear(this.timeout);

					if (this.options.navigation.test(/fast/)) {

						this.fx.each(function(fx) {

							fx.time = fx.options.duration = 0;

							fx.stop(true);

						});

					}



					this.direction = 'right';

					this.current[0] = (this.current[0] < 2) ? this.options.images.length - (2 - this.current[0]) : this.current[0] - 2;

					this.timer = [0];



					this.loader = new Image();

					this.loader.src = this.options.url + this.options.images[this.current[0]].trim();



					this.preload(this.options.navigation.test(/fast/));

				}

			}.bind(this);

			a.injectInside(li);

			li.injectInside(this.ul);

		}





		if (this.options.navigation.test(/arrows\+|thumbnails|number/)) {

			for (i = 0; i < this.options.images.length; i++) {

				li = new Element('li');

				a = new Element('a');

				a.setProperty('name', i);

				if (this.options.navigation.test(/thumbnails/)) {

					src = this.options.url + this.options.images[i].trim().replace(this.options.thumbnailre[0], this.options.thumbnailre[1]);

					a.setStyle('background-image', 'url(' + src + ')');

				}

				if(this.options.navigation.test(/number/)) {

					a.innerHTML = i+1;

				}

				if (i == 0) { a.className = this.options.classes[2]; }

				a.onclick = function(i) {

					if (this.options.navigation.test(/fast/) || (new Date).getTime() > this.timer[1]) {

						$clear(this.timeout);



						if (this.options.navigation.test(/fast/)) {

							this.fx.each(function(fx) {

								fx.time = fx.options.duration = 0;

								fx.stop(true);

							});

						}



						this.direction = (i < this.current[0] || this.current[0] == 0) ? 'right' : 'left';

						this.current[0] = i;

						this.timer = [0];



						this.loader = new Image();

						this.loader.src = this.options.url + this.options.images[this.current[0]].trim();



						this.preload(this.options.navigation.test(/fast/));

					}

				}.pass(i, this);

				a.injectInside(li);



				li.injectInside(this.ul);

			}

		}



		if (this.options.navigation.test(/arrows|number/)) {

			li = new Element('li');

			a = new Element('a');

			a.addClass(this.options.classes[1]);

			a.innerHTML = '&raquo;';

			a.onclick = function() {

				if (this.options.navigation.test(/fast/) || (new Date).getTime() > this.timer[1]) {

					$clear(this.timeout);

					if (this.options.navigation.test(/fast/)) {

						this.fx.each(function(fx) {

							fx.time = fx.options.duration = 0;

							fx.stop(true);

						});

					}

					this.timer = [0];

					this.preload(this.options.navigation.test(/fast/));

				}

			}.bind(this);

			a.injectInside(li);



			li.injectInside(this.ul);

		}

		this.buttonsp();

		this.ul.injectInside(this.bardiv);

	},



	buttonsp: function () {

			li = new Element('li');
			li.addClass("pause");

			a = new Element('a');

			a.addClass("ps");

			a.innerHTML = this.play?"<img src=\"" + this.options.siteurl + "/modules/ja_slideshow/img/pause.png\" alt=\"Pause\" title=\"Pause\">":"<img src=\"" + this.options.siteurl + "/modules/ja_slideshow/img/play.png\" alt=\"Play\" title=\"Play\">";

			a.onclick = function() {


				if(this.play){

					$clear(this.timeout);

					a.innerHTML = "<img src=\"" + this.options.siteurl + "/modules/ja_slideshow/img/play.png\" alt=\"Play\" title=\"Play\">";

					Cookie.set("JASLIDESHOWPLAY", 'pause', {duration: 365});

					this.play = 0;

				}

				else{

					Cookie.set("JASLIDESHOWPLAY", 'play', {duration: 1});

					this.play = 1;

					this.preload(false);

					a.innerHTML = "<img src=\"" + this.options.siteurl + "/modules/ja_slideshow/img/pause.png\" alt=\"Pause\" title=\"Pause\">";

				}

			}.bind(this);

			a.injectInside(li);

			li.injectInside(this.ul);

	}

});
