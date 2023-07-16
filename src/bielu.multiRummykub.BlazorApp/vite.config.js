import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

import postcssNesting from 'postcss-nesting';
import path from "path";
import glob from "glob";
// https://vitejs.dev/config/
import tailwindcss from 'tailwindcss';

export default defineConfig({

  // some other configuration
  plugins: [ vue(),tailwindcss()],
  build: {
    outDir: "./public/dist",
    rollupOptions: {
      input: {
        "js": "src/main.js",
      },
      output: {
        entryFileNames: `[name].js`,
        chunkFileNames: `[name].js`,
        assetFileNames: function (file) {
          return file.name.includes('css')
              ? `[name].[ext]`
              : `assets/[name].[ext]`;
        }
      
      }
    }
  }
})
