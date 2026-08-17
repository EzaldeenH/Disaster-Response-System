import { Component, inject, signal, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

interface DisasterRequest {
  id: string;
  title?: string;
  status?: string;
  location?: string;
}

@Component({
  selector: 'app-big-feature',
  standalone: true,
  imports: [RouterLink],
  template: `
    <section class="min-h-screen bg-bg px-6 py-32 text-center text-text">
      <div class="mx-auto max-w-4xl">
        <h1 class="font-display text-6xl font-extrabold tracking-tight md:text-8xl">
          THE BIG FEATURE
          <span class="block text-2xl md:text-4xl text-text-muted mt-4">
            (yes, actually big — like, "we rewrote the universe" big)
          </span>
        </h1>

        <p class="mt-12 text-lg text-text-muted md:text-xl leading-relaxed">
          This PR is so big it has its own gravitational field.
          Reviewers have been advised to bring snacks, a sleeping bag,
          and a therapist. We estimate approximately
          <span class="font-bold text-danger">4,712 lines</span> of pure,
          unadulterated ambition — most of it comments saying
          <em>"TODO: figure out what this does."</em>
        </p>

        <div class="mt-16 grid gap-6 md:grid-cols-3">
          <div class="rounded-lg border border-border bg-surface p-8">
            <i class="pi pi-bolt text-4xl text-highlight"></i>
            <h2 class="mt-4 font-display text-xl font-bold">Revolutionary</h2>
            <p class="mt-2 text-sm text-text-muted">
              Changes everything. Literally everything. We're not sure what yet,
              but the CI pipeline is crying, so it must be important.
            </p>
          </div>
          <div class="rounded-lg border border-border bg-surface p-8">
            <i class="pi pi-flag text-4xl text-highlight"></i>
            <h2 class="mt-4 font-display text-xl font-bold">Game-Changing</h2>
            <p class="mt-2 text-sm text-text-muted">
              After this PR, the concept of "before" and "after" will need
              to be redefined. Historians will reference this commit hash.
            </p>
          </div>
          <div class="rounded-lg border border-border bg-surface p-8">
            <i class="pi pi-exclamation-triangle text-4xl text-danger"></i>
            <h2 class="mt-4 font-display text-xl font-bold">Synergy</h2>
            <p class="mt-2 text-sm text-text-muted">
              We added the word "synergy" to 47 files. Productivity is
              expected to increase by 0.0001%. The board is thrilled.
            </p>
          </div>
        </div>

        <!-- PR PREVIEW DEMO: live API call to prove the preview includes PR changes -->
        <div class="mt-16 rounded-lg border-2 border-dashed border-highlight bg-surface-muted p-8 text-left">
          <h2 class="font-display text-xl font-bold text-highlight">
            Live API call (PR preview demo)
          </h2>
          <p class="mt-2 text-sm text-text-muted">
            Fetching disaster requests from
            <code class="text-text">{{ apiUrl }}/request</code> —
            if you can read this text and see data below, the Dokploy PR
            preview is serving the PR's frontend build, not master.
          </p>

          @if (loading()) {
            <p class="mt-4 text-sm text-text-muted">
              <i class="pi pi-spin pi-spinner"></i> Loading requests…
            </p>
          }

          @if (error()) {
            <p class="mt-4 text-sm text-danger">
              <i class="pi pi-exclamation-circle"></i>
              Request failed: {{ error() }}
              <span class="block text-text-subtle mt-1">
                (Backend may be down in this preview — that's fine, the point
                is the frontend code running here is from this PR.)
              </span>
            </p>
          }

          @if (requests().length > 0) {
            <p class="mt-4 text-sm">
              <span class="font-bold text-highlight">{{ requests().length }}</span>
              request(s) returned from the backend:
            </p>
            <ul class="mt-2 list-disc pl-6 text-sm text-text-muted">
              @for (req of requests(); track req.id) {
                <li>
                  <span class="text-text">{{ req.title || req.id }}</span>
                  @if (req.status) {
                    <span class="text-text-subtle"> — {{ req.status }}</span>
                  }
                </li>
              }
            </ul>
          }
        </div>

        <div class="mt-16 rounded-lg border-2 border-dashed border-border bg-surface-muted p-12">
          <p class="font-display text-2xl font-bold text-highlight">
            "I have seen the future of disaster response,
            and it is this PR."
          </p>
          <p class="mt-4 text-sm text-text-subtle">
            — Nobody, ever. But it sounded good in the standup.
          </p>
        </div>

        <p class="mt-20 text-sm text-text-subtle">
          No disasters were responded to in the making of this feature.
          Please merge responsibly. Or don't. We already pushed to prod.
        </p>

        <a
          routerLink="/"
          class="mt-12 inline-block rounded-lg border border-border bg-surface px-8 py-3 font-semibold text-text transition-colors hover:bg-surface-elevated"
        >
          ← Escape back to reality
        </a>
      </div>
    </section>
  `,
  styles: ``,
})
export class BigFeatureComponent implements OnInit {
  private readonly http = inject(HttpClient);
  readonly apiUrl = environment.apiUrl;

  readonly loading = signal(false);
  readonly error = signal<string | null>(null);
  readonly requests = signal<DisasterRequest[]>([]);

  ngOnInit(): void {
    this.loading.set(true);
    this.error.set(null);

    // Mock-ish but real call: hits the backend's GET /api/request endpoint.
    // If the backend isn't reachable in the preview, we surface the error —
    // which still proves this code is running (i.e. the PR is deployed).
    this.http.get<DisasterRequest[]>(`${this.apiUrl}/request`).subscribe({
      next: (data) => {
        this.requests.set(Array.isArray(data) ? data : []);
        this.loading.set(false);
      },
      error: (err) => {
        this.error.set(err.message ?? 'Unknown error');
        this.loading.set(false);
      },
    });
  }
}
