using FrdCoreCrypt.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FrdCoreCrypt.Objects
{
    public class CertSubjectDetails
    {

        Dictionary<string, Claim> _claims = new Dictionary<string, Claim>();
        string _serialNUmber, _commonname, _givenname,
            _title, _surname, _org, _orgUnit, _email,
            _userID, _loyality, _initials, _postCodes,
            _stateProvince, _country = null;



        public string SerialNumber
        {
            get { return _serialNUmber; }
            set
            {
                _serialNUmber = value;
                if (_serialNUmber == null)
                {
                    _claims.Remove(CertificateClaims.SubjectSerialNumber);
                }
                else
                {
                    if (_claims.ContainsKey(CertificateClaims.SubjectSerialNumber))
                    {
                        _claims[CertificateClaims.SubjectSerialNumber] = new Claim(CertificateClaims.SubjectSerialNumber, _serialNUmber);

                    }
                    else
                    {
                        _claims.Add(CertificateClaims.SubjectSerialNumber, new Claim(CertificateClaims.SubjectSerialNumber, _serialNUmber));
                    }

                }

            }
        }
        public string CommonName
        {
            get { return _commonname; }
            set
            {
                _commonname = value;
                if (_commonname == null)
                {
                    _claims.Remove(CertificateClaims.SubjectCommonName);
                }
                else
                {
                    if (_claims.ContainsKey(CertificateClaims.SubjectCommonName))
                    {
                        _claims[CertificateClaims.SubjectCommonName] = new Claim(CertificateClaims.SubjectCommonName, _commonname);

                    }
                    else
                    {
                        _claims.Add(CertificateClaims.SubjectCommonName, new Claim(CertificateClaims.SubjectCommonName, _commonname));
                    }

                }

            }
        }

        public string GivenName
        {
            get { return _givenname; }
            set
            {
                _givenname = value;
                if (_givenname == null)
                {
                    _claims.Remove(CertificateClaims.SubjectGivenName);
                }
                else
                {
                    if (_claims.ContainsKey(CertificateClaims.SubjectGivenName))
                    {
                        _claims[CertificateClaims.SubjectGivenName] = new Claim(CertificateClaims.SubjectGivenName, _givenname);

                    }
                    else
                    {
                        _claims.Add(CertificateClaims.SubjectGivenName, new Claim(CertificateClaims.SubjectGivenName, _givenname));
                    }

                }

            }
        }
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                if (_title == null)
                {
                    _claims.Remove(CertificateClaims.SubjectTitle);
                }
                else
                {
                    if (_claims.ContainsKey(CertificateClaims.SubjectTitle))
                    {
                        _claims[CertificateClaims.SubjectTitle] = new Claim(CertificateClaims.SubjectTitle, _title);

                    }
                    else
                    {
                        _claims.Add(CertificateClaims.SubjectTitle, new Claim(CertificateClaims.SubjectTitle, _title));
                    }

                }

            }
        }


        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                if (_surname == null)
                {
                    _claims.Remove(CertificateClaims.SubjectSurname);
                }
                else
                {
                    if (_claims.ContainsKey(CertificateClaims.SubjectSurname))
                    {
                        _claims[CertificateClaims.SubjectSurname] = new Claim(CertificateClaims.SubjectSurname, _surname);

                    }
                    else
                    {
                        _claims.Add(CertificateClaims.SubjectSurname, new Claim(CertificateClaims.SubjectSurname, _surname));
                    }

                }

            }
        }

        public string Organisation
        {
            get { return _org; }
            set
            {
                _org = value;
                if (_org == null)
                {
                    _claims.Remove(CertificateClaims.SubjectOrganisation);
                }
                else
                {
                    if (_claims.ContainsKey(CertificateClaims.SubjectOrganisation))
                    {
                        _claims[CertificateClaims.SubjectOrganisation] = new Claim(CertificateClaims.SubjectOrganisation, _org);

                    }
                    else
                    {
                        _claims.Add(CertificateClaims.SubjectOrganisation, new Claim(CertificateClaims.SubjectOrganisation, _org));
                    }

                }

            }
        }

        public string OrganisationUnit
        {
            get { return _orgUnit; }
            set
            {
                _orgUnit = value;
                if (_orgUnit == null)
                {
                    _claims.Remove(CertificateClaims.SubjectOrganisationUnit);
                }
                else
                {
                    if (_claims.ContainsKey(CertificateClaims.SubjectOrganisationUnit))
                    {
                        _claims[CertificateClaims.SubjectOrganisationUnit] = new Claim(CertificateClaims.SubjectOrganisationUnit, _orgUnit);

                    }
                    else
                    {
                        _claims.Add(CertificateClaims.SubjectOrganisationUnit, new Claim(CertificateClaims.SubjectOrganisationUnit, _orgUnit));
                    }

                }

            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                if (_email == null)
                {
                    _claims.Remove(CertificateClaims.SubjectEmail);
                }
                else
                {
                    if (_claims.ContainsKey(CertificateClaims.SubjectEmail))
                    {
                        _claims[CertificateClaims.SubjectEmail] = new Claim(CertificateClaims.SubjectEmail, _email);

                    }
                    else
                    {
                        _claims.Add(CertificateClaims.SubjectEmail, new Claim(CertificateClaims.SubjectEmail, _email));
                    }

                }

            }
        }

        public string UserId
        {
            get { return _userID; }
            set
            {
                _userID = value;
                if (_userID == null)
                {
                    _claims.Remove(CertificateClaims.SubjectUserid);
                }
                else
                {
                    if (_claims.ContainsKey(CertificateClaims.SubjectUserid))
                    {
                        _claims[CertificateClaims.SubjectUserid] = new Claim(CertificateClaims.SubjectUserid, _userID);

                    }
                    else
                    {
                        _claims.Add(CertificateClaims.SubjectUserid, new Claim(CertificateClaims.SubjectUserid, _userID));
                    }

                }

            }
        }

        public string Loyality
        {
            get { return _loyality; }
            set
            {
                _loyality = value;
                if (_loyality == null)
                {
                    _claims.Remove(CertificateClaims.SubjectLoyality);
                }
                else
                {
                    if (_claims.ContainsKey(CertificateClaims.SubjectLoyality))
                    {
                        _claims[CertificateClaims.SubjectLoyality] = new Claim(CertificateClaims.SubjectLoyality, _loyality);

                    }
                    else
                    {
                        _claims.Add(CertificateClaims.SubjectLoyality, new Claim(CertificateClaims.SubjectLoyality, _loyality));
                    }

                }

            }
        }

        public string Initials
        {
            get { return _initials; }
            set
            {
                _initials = value;
                if (_initials == null)
                {
                    _claims.Remove(CertificateClaims.SubjectInitials);
                }
                else
                {
                    if (_claims.ContainsKey(CertificateClaims.SubjectInitials))
                    {
                        _claims[CertificateClaims.SubjectInitials] = new Claim(CertificateClaims.SubjectInitials, _initials);

                    }
                    else
                    {
                        _claims.Add(CertificateClaims.SubjectInitials, new Claim(CertificateClaims.SubjectInitials, _initials));
                    }

                }

            }
        }

        public string PostalCode
        {
            get { return _postCodes; }
            set
            {
                _postCodes = value;
                if (_postCodes == null)
                {
                    _claims.Remove(CertificateClaims.SubjectPostalCode);
                }
                else
                {
                    if (_claims.ContainsKey(CertificateClaims.SubjectPostalCode))
                    {
                        _claims[CertificateClaims.SubjectPostalCode] = new Claim(CertificateClaims.SubjectPostalCode, _postCodes);

                    }
                    else
                    {
                        _claims.Add(CertificateClaims.SubjectPostalCode, new Claim(CertificateClaims.SubjectPostalCode, _postCodes));
                    }

                }

            }
        }

        public string StateProvince
        {
            get { return _stateProvince; }
            set
            {
                _stateProvince = value;
                if (_stateProvince == null)
                {
                    _claims.Remove(CertificateClaims.SubjectStateProvince);
                }
                else
                {
                    if (_claims.ContainsKey(CertificateClaims.SubjectStateProvince))
                    {
                        _claims[CertificateClaims.SubjectStateProvince] = new Claim(CertificateClaims.SubjectStateProvince, _stateProvince);

                    }
                    else
                    {
                        _claims.Add(CertificateClaims.SubjectStateProvince, new Claim(CertificateClaims.SubjectStateProvince, _stateProvince));
                    }

                }

            }
        }

        public string Country
        {
            get { return _country; }
            set
            {
                _country = value;
                if (_country == null)
                {
                    _claims.Remove(CertificateClaims.SubjectCountry);
                }
                else
                {
                    if (_claims.ContainsKey(CertificateClaims.SubjectCountry))
                    {
                        _claims[CertificateClaims.SubjectCountry] = new Claim(CertificateClaims.SubjectCountry, _country);

                    }
                    else
                    {
                        _claims.Add(CertificateClaims.SubjectCountry, new Claim(CertificateClaims.SubjectCountry, _country));
                    }

                }

            }
        }


        public Dictionary<string, Claim> Claims
        {
            get
            {
                return _claims;
            }
        }



    }
}
