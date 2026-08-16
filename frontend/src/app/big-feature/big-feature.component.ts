import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

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
export class BigFeatureComponent {}
