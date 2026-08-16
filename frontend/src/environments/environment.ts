/** Production environment. Used by `ng build` (default config).
 *  For Dokploy: change apiUrl to your public API domain, e.g. 'https://api.yourdomain.com/api'
 *  Or use '/api' if Traefik routes /api/* to the backend on the same domain. */
export const environment = {
  production: true,
  apiUrl: 'http://localhost:8080/api',
};
