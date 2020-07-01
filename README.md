# blazor-wasm-interop
Explores the WebAssembly.Bindings assembly

Blogged about this application. You will find the blog on the following url: http://cveld.blogspot.com/2020/07/exploring-advanced-dom-interop-with.html

This application integrates a particular Mono WebAssembly html5 bindings example from one of the mono core team developers kjpou1: CanvasAnimation with Blazor.
Link to this example on his GitHub repo: 
https://github.com/kjpou1/wasm-dom/tree/master/samples/CanvasAnimation

In order to get this application built you will need two external dependencies:

1. WebAssembly.Browser project
The WebAssembly.Browser project is taken from the the following GitHub repository:
https://github.com/kjpou1/wasm-dom

2. WebAssembly.Bindings.dll assembly
WebAssembly.Bindings.dll is part of the Mono Wasm sdk. Read their documentation to get a copy:
https://github.com/mono/mono/blob/master/sdks/wasm/docs/getting-started/obtain-wasm-sdk.md