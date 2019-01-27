# pixcolor
A small nodejs utility to get the color of a pixel on the desktop screen.

## Usage

`npm i pixcolor`

```js
import pixcolor from pixcolor;

// synchronous usage
const color = pixcolor([100, 200], true);

// async usage
pixcolor([100, 200], (err, color) => {

});
```

The return value will be in the format `RRGGBB` like a hex color, but it doesn't have an octothorpe prepended.

## Restrictions

This uses [edge-js](https://github.com/agracio/edge-js), so it only runs on windows, and from a node environment - it will not work in the browser.