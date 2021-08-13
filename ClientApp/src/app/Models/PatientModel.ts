import {Sex} from "./Sex";

interface DPModel {
  isActive: boolean;
  name: string;
  flags: string[];
  description: string;
}

export interface PatientModel
{
  id: string;
  name: string;
  sex: Sex;
  birthday: Date;
  departamentId: string;
  diagnoses: DPModel[];
  procedures: DPModel[];
}
