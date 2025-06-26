import { Provider } from "@angular/core";
import { MAT_MOMENT_DATE_ADAPTER_OPTIONS, MatMomentDateModule, provideMomentDateAdapter } from "@angular/material-moment-adapter";
import { MAT_DATE_FORMATS, MAT_DATE_LOCALE, MatDateFormats } from "@angular/material/core";

export const MY_DATE_FORMATS = {
  parse: {
    dateInput: 'DD/MM/YYYY',
  },
  display: {
    dateInput: 'DD/MM/YYYY',
    monthYearLabel: 'MMMM YYYY',
    dateA11yLabel: 'LL',
    monthYearA11yLabel: 'MMMM YYYY',
  }
};

export function provideDate(): Provider[] {
  return [
    MatMomentDateModule,
    { provide: MAT_DATE_FORMATS, useValue: MY_DATE_FORMATS },
    { provide: MAT_DATE_LOCALE, useValue: 'es-ES' }, //
    { provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: { useUtc: false } },
  ];
}
