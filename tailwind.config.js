/** @type {import('tailwindcss').Config} */
module.exports = {
  darkMode: 'class', // important for manual toggle
  content: [
    './Views/**/*.cshtml',
    './wwwroot/**/*.js'
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}

