import {CodeResult} from "./CodeResult";

export interface PatientResult
{
  diagnoses: CodeResult[];
  procedures: CodeResult[];
  mdc: string;
  mdcDescription: string;
  drg: string;
  drgDescription: string;
  entgelt: number;
}
