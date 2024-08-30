import defaultTheme from 'tailwindcss/defaultTheme';

/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['../Wardrobe.frockett.wasm/**/*.{razor,html,cshtml}'],
  theme: {
    extend: {
      fontFamily: {
        sans: ['Noto Sans', 'Times New Roman', ...defaultTheme.fontFamily.sans],
      },
    },
  },
  plugins: [],
};
