/**
 * plugins/vuetify.ts
 *
 * Framework documentation: https://vuetifyjs.com`
 */

// Styles
import '@mdi/font/css/materialdesignicons.css'
import 'vuetify/styles'

// Composables
import { createVuetify } from 'vuetify'

// https://piktochart.com/blog/green-color-palette-combinations/#3-enchanted-forest
const enchantedForestTheme = {
  dark: false,
  colors: {
    primary: '#6EEA8E',
    'on-primary': "#FFFFFF",
    secondary: '#FFFFFF',
    'on-secondary': "#826CF6",
    anyColor: '#FFFFFF',
    background: '#FFFFFF',
    'on-background': '#000000',
    surface: '#006600', // 1c2a18
    'on-surface': '#ffffcc',
  }
}

// https://vuetifyjs.com/en/introduction/why-vuetify/#feature-guides
export default createVuetify({
  theme: {
    // defaultTheme: 'system',
    defaultTheme: 'enchantedForestTheme',
    themes: {
      enchantedForestTheme,
    }
  },
})
