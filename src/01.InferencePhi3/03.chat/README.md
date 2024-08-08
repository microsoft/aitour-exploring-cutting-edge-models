### 03.WebGPU
Required Environment:

**Supported browsers:** 
- Google Chrome 113+
- Microsoft Edge 113+
- Safari 18 (macOS 15)
- Firefox Nightly.

### Enable WebGPU:
- In Chrome/Microsoft Edge, enable the `chrome://flags/#enable-unsafe-webgpu` flag.
- For Linux, launch the browser with `--enable-features=Vulkan`.
- Safari 18 (macOS 15) has WebGPU enabled by default.
- In Firefox Nightly, enter about:config in the address bar and `set dom.webgpu.enabled to true`.

Run the following command to get strated 
```
npm run build
```
```
npm run dev
```

### WebGPU Demo

**Note:** The model needs to be cached in the browser, so it may take some time to load. Upload the markdown file `intro_rag.md` to complete the RAG solution.