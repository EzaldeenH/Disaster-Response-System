/** Production environment. Used by `ng build` (default config).
 *  The backend is deployed as a separate Dokploy Application with its own
 *  domain. apiUrl points to the backend's public URL.
 *  CORS on the backend must allow the frontend's origin. */
export const environment = {
  production: true,
  apiUrl: 'http://drs-backend.158.158.72.65.nip.io/api',
};
