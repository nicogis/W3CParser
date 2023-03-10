using System;

namespace W3CParser.Enumerators
{
    

    public enum ALG_ID: long
    {
        CALG_OID_INFO_CNG_ONLY = 4294967295,
        CALG_OID_INFO_PARAMETERS = 4294967294,

        None = 0,
        CALG_3DES = 26115,
        CALG_3DES_112 = 26121,
        CALG_AES = 26129,
        CALG_AES_128 = 26126,
        CALG_AES_192 = 26127,
        CALG_AES_256 = 26128,
        CALG_AGREEDKEY_ANY = 43523,
        CALG_CYLINK_MEK = 26124,
        CALG_DES = 26113,
        CALG_DESX = 26116,
        CALG_DH_EPHEM = 43522,
        CALG_DH_SF = 43521,
        CALG_DSS_SIGN = 8704,
        CALG_ECDH = 43525,
        CALG_ECDH_EPHEM = 44550,
        CALG_ECDSA = 8707,
        CALG_ECMQV = 40961,
        CALG_HASH_REPLACE_OWF = 32779,
        CALG_HUGHES_MD5 = 40963,
        CALG_HMAC = 32777,
        CALG_KEA_KEYX = 43524,
        CALG_MAC = 32773,
        CALG_MD2 = 32769,
        CALG_MD4 = 32770,
        CALG_MD5 = 32771,
        CALG_NO_SIGN = 8192,
        CALG_PCT1_MASTER = 19460,
        CALG_RC2 = 26114,
        CALG_RC4 = 26625,
        CALG_RC5 = 26125,
        CALG_RSA_KEYX = 41984,
        CALG_RSA_SIGN = 9216,
        CALG_SCHANNEL_ENC_KEY = 19463,
        CALG_SCHANNEL_MAC_KEY = 19459,
        CALG_SCHANNEL_MASTER_HASH = 19458,
        CALG_SEAL = 26626,
        CALG_SHA = 32772,
        CALG_SHA1 = 32772,
        CALG_SHA_256 = 32780,
        CALG_SHA_384 = 32781,
        CALG_SHA_512 = 32782,
        CALG_SKIPJACK = 26122,
        CALG_SSL2_MASTER = 19461,
        CALG_SSL3_MASTER = 19457,
        CALG_SSL3_SHAMD5 = 32776,
        CALG_TEK = 26123,
        CALG_TLS1_MASTER = 19462,
        CALG_TLS1PRF = 32778
    }
}
