import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { providePrimeNG } from 'primeng/config';
import { definePreset } from '@primeuix/themes';
import Aura from '@primeuix/themes/aura';

import { routes } from './app.routes';

/**
 * PrimeNG preset derived from Aura, repointed at our CSS variables so the
 * whole UI (PrimeNG + Tailwind + raw CSS) shares one palette defined in
 * `src/styles.css`. To retheme the app, edit the :root vars in styles.css.
 *
 * Design: monochrome (neutral grays) + white accent. The primary ramp
 * runs white -> gray so default p-buttons, checked radios, focus rings,
 * etc. render white-on-dark, matching the black-and-white hero.
 */
const HelpingHandsPreset = definePreset(Aura, {
  semantic: {
    primary: {
      50: 'rgba(255, 255, 255, 0.10)',
      100: '#f5f5f4',
      200: '#e4e4e7',
      300: '#d4d4d8',
      400: 'var(--color-accent)',
      500: 'var(--color-accent)',
      600: 'var(--color-accent)',
      700: 'var(--color-accent-hover)',
      800: 'var(--color-accent-active)',
      900: '#71717a',
      950: '#3f3f46',
    },
    colorScheme: {
      light: {
        surface: {
          0: '#0a0a0a',
          50: '#141414',
          100: '#1a1a1a',
          200: '#1f1f1f',
          300: '#262626',
          400: '#404040',
          500: '#525252',
          600: '#737373',
          700: '#a3a3a3',
          800: '#d4d4d4',
          900: '#f5f5f5',
          950: '#ffffff',
        },
        primary: {
          color: 'var(--color-accent)',
          contrastColor: 'var(--color-accent-contrast)',
          hoverColor: 'var(--color-accent-hover)',
          activeColor: 'var(--color-accent-active)',
        },
      },
      dark: {
        surface: {
          0: '#0a0a0a',
          50: '#141414',
          100: '#1a1a1a',
          200: '#1f1f1f',
          300: '#262626',
          400: '#404040',
          500: '#525252',
          600: '#737373',
          700: '#a3a3a3',
          800: '#d4d4d4',
          900: '#f5f5f5',
          950: '#ffffff',
        },
        primary: {
          color: 'var(--color-accent)',
          contrastColor: 'var(--color-accent-contrast)',
          hoverColor: 'var(--color-accent-hover)',
          activeColor: 'var(--color-accent-active)',
        },
      },
    },
  },
});

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideHttpClient(),
    provideAnimationsAsync(),
    providePrimeNG({
      theme: {
        preset: HelpingHandsPreset,
        options: {
          darkModeSelector: '.app-dark',
          cssLayer: {
            name: 'primeng',
            order: 'theme, base, primeng, components, utilities',
          },
        },
      },
    }),
  ],
};
