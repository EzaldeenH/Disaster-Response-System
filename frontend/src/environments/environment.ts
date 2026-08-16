/** Production environment. Used by `ng build` (default config).
 *  apiUrl is relative so the frontend nginx proxies /api to the backend container
 *  over the Docker network. Works on Dokploy (dokploy-network) and locally. */
export const environment = {
  production: true,
  apiUrl: '/api',
};
